using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Create
{
    public class CreateReceiptCommandHandler : BaseHandler, IRequestHandler<CreateReceiptCommandRequest, ResponseDto<CreateReceiptCommandResponse>>
    {
        public CreateReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateReceiptCommandResponse>> Handle(CreateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            var stockData = await unitOfWork.GetReadRepository<Stock>().GetAllAsync(x => !x.IsDeleted);

            var accountData = await unitOfWork.GetReadRepository<Account>().GetAsync(c => !c.IsDeleted && c.Id == request.AccountId);

            if (request.CreateMovementReceiptRequestDtos != null)
            {

                var counterList = new List<CreateMovementReceiptRequestDto>();
                foreach (var item in request.CreateMovementReceiptRequestDtos)
                {
                    counterList.Add(item);

                    int counterTransactionTypeId = 0;
                    switch (item.TransactionTypeId)
                    {
                        case 1: counterTransactionTypeId = 2; break; // Nakit Giriþ -> Çýkýþ
                        case 2: counterTransactionTypeId = 1; break; // Nakit Çýkýþ -> Giriþ
                        case 3: counterTransactionTypeId = 4; break; // Ürün Giriþ -> Çýkýþ
                        case 4: counterTransactionTypeId = 3; break; // Ürün Çýkýþ -> Giriþ
                        case 5: counterTransactionTypeId = 6; break; // Ýskonto Alacak -> Borç
                        case 6: counterTransactionTypeId = 5; break; // Ýskonto Borç -> Alacak
                        case 7: counterTransactionTypeId = 8; break; // Virman Giriþ -> Çýkýþ
                        case 8: counterTransactionTypeId = 7; break; // Virman Çýkýþ -> Giriþ
                        case 9: counterTransactionTypeId = 10; break; // Çevirme Giriþ -> Çýkýþ
                        case 10: counterTransactionTypeId = 9; break; // Çevirme Çýkýþ -> Giriþ
                        default: counterTransactionTypeId = item.TransactionTypeId; break;
                    }

                    var counter = new CreateMovementReceiptRequestDto
                    {
                        MovementId = 0,
                        TransactionTypeId = counterTransactionTypeId,
                        AccountId = item.AccountId,
                        Description = request.IsCustomerReceipt ? $"Cari:{accountData.AccountName} Karþý Hareket" : "", // Sabit açýklama eklenebilir
                        IsDeleted = item.IsDeleted,
                        StockId = item.StockId,
                        BaseCurrencyAmount = item.BaseCurrencyAmount,
                        CostAmount = item.CostAmount,
                        ProfitAmount = item.ProfitAmount,
                        Quantity = item.Quantity,
                        MillRate = item.MillRate,
                        LaborCost = item.LaborCost,
                        LaborUnit = item.LaborUnit,
                        LaborQuantity = item.LaborQuantity,
                        IsLaborIncluded = item.IsLaborIncluded,
                        IsReconciled = item.IsReconciled,
                        NetProductValue = item.NetProductValue,
                        TotalLaborCost = item.TotalLaborCost
                    };

                    if (item.StockId != null)
                    {
                        // For products, don't flip Foreign and Counter amounts
                        counter.ForeignCurrencyAmount = item.ForeignCurrencyAmount;
                        counter.ForeignCurrencyId = item.ForeignCurrencyId;
                        counter.ForeignExchangeRate = item.ForeignExchangeRate;
                        counter.CounterCurrencyAmount = item.CounterCurrencyAmount;
                        counter.CounterCurrencyId = item.CounterCurrencyId;
                        counter.CounterExchangeRate = item.CounterExchangeRate;
                        var data = stockData.FirstOrDefault(c => c.Id == item.StockId);
                        if (data is null)
                        {
                            throw new Exception("Ýlgili Stok Bulunamadý");
                        }
                        counter.AccountId = ReturnAccountIdByStockId(data);
                        item.NetProductValue = item.MillRate * item.Quantity;
                        counter.NetProductValue = item.NetProductValue;
                    }
                    else
                    {
                        // Flip Foreign and Counter for everything else
                        counter.ForeignCurrencyAmount = item.CounterCurrencyAmount;
                        counter.ForeignCurrencyId = item.CounterCurrencyId;
                        counter.ForeignExchangeRate = item.CounterExchangeRate;
                        counter.CounterCurrencyAmount = item.ForeignCurrencyAmount;
                        counter.CounterCurrencyId = item.ForeignCurrencyId;
                        counter.CounterExchangeRate = item.ForeignExchangeRate;
                    }

                    counterList.Add(counter);

                }
                request.CreateMovementReceiptRequestDtos = counterList;
            }

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            // Request'i tek çaðrýda Receipt entity'sine map et
            var receipt = mapper.Map<Receipt, CreateReceiptCommandRequest>(request);


            receipt.CreatedByUserId = 1;

            await unitOfWork.GetWriteRepository<Receipt>().AddAsync(receipt);

            await unitOfWork.SaveAsync();

            // Eðer hareket DTO'larý geldiyse, Movements listesine map et ve Receipt'e ata
            if (request.CreateMovementReceiptRequestDtos != null && request.CreateMovementReceiptRequestDtos.Any())
            {
                var movements = mapper.Map<Movements, CreateMovementReceiptRequestDto>(request.CreateMovementReceiptRequestDtos);




                for (int i = 0; i < movements.Count; i += 2)
                {
                    var movementData = movements[i];
                    var movementDataTwo = movements[i + 1];

                    movementData.ReceiptId = receipt.Id;
                    movementData.CreatedByUserId = 1;

                    await unitOfWork.GetWriteRepository<Movements>().AddAsync(movementData);

                    await unitOfWork.SaveAsync();

                    movementDataTwo.ReceiptId = receipt.Id;
                    movementDataTwo.CounterTransactionId = movementData.Id;
                    movementDataTwo.CreatedByUserId = 1;

                    await unitOfWork.GetWriteRepository<Movements>().AddAsync(movementDataTwo);

                    await unitOfWork.SaveAsync();

                    movementData.CounterTransactionId = movementDataTwo.Id;

                    await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(movementData);
                    await unitOfWork.SaveAsync();
                }

            }

            await unitOfWork.CommitAsync();

            return new ResponseDto<CreateReceiptCommandResponse>().Success();
        }
        public int ReturnAccountIdByStockId(Stock data)
        {
            switch (data.StockGroupId)
            {
                case 2: return 37;
                case 3: return 34;
                case 1: return 41;
                default: return 0;
            }
        }
    }
}
