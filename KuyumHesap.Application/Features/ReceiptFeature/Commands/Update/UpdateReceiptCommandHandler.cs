using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Update
{
    public class UpdateReceiptCommandHandler : BaseHandler, IRequestHandler<UpdateReceiptCommandRequest, ResponseDto<UpdateReceiptCommandResponse>>
    {
        int cashLastId = 0;
        int accounId;
        int currentAccounId = 0;

        public UpdateReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateReceiptCommandResponse>> Handle(UpdateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            await UpdateCashModal(request, cancellationToken);
            return new ResponseDto<UpdateReceiptCommandResponse>().Success();
        }

        public async Task UpdateCashModal(UpdateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var settings = await unitOfWork.GetReadRepository<Setting>().GetAllAsync(x => !x.IsDeleted);
                
                int defaultCashAccountId = int.TryParse(settings.FirstOrDefault(s => s.Key == "DefaultCashAccountId")?.Value, out var dcid) ? dcid : 1;
                int defaultDiscountAccountId = int.TryParse(settings.FirstOrDefault(s => s.Key == "DefaultDiscountAccountId")?.Value, out var ddid) ? ddid : 3;

                accounId = request.AccountId;
                currentAccounId = request.CurrentAccountId;

                var data = await unitOfWork.GetReadRepository<Receipt>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);
                var deleteByReceiptId = await unitOfWork.GetReadRepository<Movements>().GetAllAsync(x => !x.IsDeleted && x.ReceiptId == request.Id);

                await unitOfWork.OpenTransactionAsync(cancellationToken);

                foreach (var item in deleteByReceiptId)
                {
                    item.IsDeleted = true;
                    await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(item);
                }

                var receipt = mapper.Map(request, data);
                receipt.AccountId = request.CurrentAccountId;
                // Preserve CreatedByUserId
                
                await unitOfWork.GetWriteRepository<Receipt>().UpdateAsync(receipt);
                await unitOfWork.SaveAsync(cancellationToken);

                var movements = mapper.Map<Movements, CreateMovementReceiptRequestDto>(request.UpdateMovementReceiptRequestDtos);

                foreach (var movement in movements)
                {
                    if (!receipt.IsCustomerReceipt)
                    {
                        movement.ReceiptId = receipt.Id;
                        movement.CostAmount = movement.CounterCurrencyAmount;
                        request.AccountId = defaultCashAccountId;
                        
                        await ProcessMovementPairAsync(movement, request, receipt, movements, defaultDiscountAccountId, cancellationToken);
                    }
                    else
                    {
                        movement.ReceiptId = receipt.Id;
                        await unitOfWork.GetWriteRepository<Movements>().AddAsync(movement);
                    }
                }

                await unitOfWork.SaveAsync(cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                try
                {
                    await unitOfWork.RollBackAsync(cancellationToken);
                }
                catch { }
                throw;
            }
        }

        private async Task ProcessMovementPairAsync(Movements movement, UpdateReceiptCommandRequest request, Receipt receipt, IEnumerable<Movements> allMovements, int defaultDiscountAccountId, CancellationToken cancellationToken)
        {
            switch (movement.TransactionTypeId)
            {
                case 1:
                    await HandlePrimaryThenCounterAsync(movement, request, receipt, 2, 2, 1, defaultDiscountAccountId, cancellationToken);
                    break;
                case 2:
                    await HandleCounterThenPrimaryAsync(movement, request, receipt, 1, 1, 2, defaultDiscountAccountId, cancellationToken);
                    break;
                case 5:
                    await HandlePrimaryThenCounterAsync(movement, request, receipt, 6, 6, 5, defaultDiscountAccountId, cancellationToken);
                    break;
                case 6:
                    await HandleCounterThenPrimaryAsync(movement, request, receipt, 5, 5, 6, defaultDiscountAccountId, cancellationToken);
                    break;
                case 7:
                    await HandleCounterThenPrimaryAsync(movement, request, receipt, 8, 8, 7, defaultDiscountAccountId, cancellationToken);
                    break;
                case 8:
                    await HandleCounterThenPrimaryAsync(movement, request, receipt, 7, 7, 8, defaultDiscountAccountId, cancellationToken);
                    break;
                default:
                    await unitOfWork.GetWriteRepository<Movements>().AddAsync(movement);
                    await unitOfWork.SaveAsync(cancellationToken);
                    break;
            }

            async Task HandlePrimaryThenCounterAsync(Movements primary, UpdateReceiptCommandRequest req, Receipt rec, int counterTransactionType, int descriptionSourceType, int isProccessingNo, int discountAccountId, CancellationToken ct)
            {
                primary.AccountId = req.CurrentAccountId;
                primary.ReceiptId = rec.Id;
                primary.CostAmount = primary.CounterCurrencyAmount;
                await unitOfWork.GetWriteRepository<Movements>().AddAsync(primary);
                await unitOfWork.SaveAsync(ct);

                var counter = mapper.Map<Movements, Movements>(primary);
                counter.Id = 0;
                counter.AccountId = counterTransactionType == 6 ? discountAccountId : req.AccountId;
                counter.TransactionTypeId = counterTransactionType;
                counter.CounterCurrencyId = primary.ForeignCurrencyId;
                counter.CounterTransactionId = primary.Id;
                counter.CounterCurrencyAmount = primary.ForeignCurrencyAmount;
                counter.CostAmount = primary.CounterCurrencyAmount;
                counter.IsDeleted = false;
                counter.Description = allMovements.Where(y => y.TransactionTypeId == descriptionSourceType).Select(x => x.Description).FirstOrDefault() ?? "";

                await unitOfWork.GetWriteRepository<Movements>().AddAsync(counter);
                await unitOfWork.SaveAsync(ct);

                primary.CounterTransactionId = counter.Id;
                counter.CounterTransactionId = primary.Id;

                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(primary);
                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(counter);
                await unitOfWork.SaveAsync(ct);
            }

            async Task HandleCounterThenPrimaryAsync(Movements counterDefinition, UpdateReceiptCommandRequest req, Receipt rec, int primaryTransactionType, int descriptionSourceType, int isProccessingNo, int discountAccountId, CancellationToken ct)
            {
                var counter = mapper.Map<Movements, Movements>(counterDefinition);
                counter.AccountId = primaryTransactionType == 5 || primaryTransactionType == 8 || primaryTransactionType == 7 ? currentAccounId : accounId;
                if (isProccessingNo == 2)
                {
                    counter.AccountId = req.CurrentAccountId;
                }
                counter.ReceiptId = rec.Id;
                counter.CounterCurrencyAmount = counterDefinition.CounterCurrencyAmount;
                counter.CounterCurrencyId = counterDefinition.CounterCurrencyId;
                counter.CostAmount = counterDefinition.CounterCurrencyAmount;

                await unitOfWork.GetWriteRepository<Movements>().AddAsync(counter);
                await unitOfWork.SaveAsync(ct);

                counterDefinition.Description = allMovements.Where(y => y.TransactionTypeId == descriptionSourceType).Select(x => x.Description).FirstOrDefault() ?? "";
                counterDefinition.CounterTransactionId = counter.Id;
                counterDefinition.TransactionTypeId = primaryTransactionType;
                counterDefinition.CostAmount = counterDefinition.CounterCurrencyAmount;
                counterDefinition.ReceiptId = rec.Id;
                counterDefinition.AccountId = primaryTransactionType == 5 ? discountAccountId : req.AccountId;
                counterDefinition.IsDeleted = false;
                counterDefinition.Id = 0;
                counterDefinition.CounterCurrencyAmount = counter.ForeignCurrencyAmount;
                counterDefinition.CounterCurrencyId = counter.ForeignCurrencyId;

                await unitOfWork.GetWriteRepository<Movements>().AddAsync(counterDefinition);
                await unitOfWork.SaveAsync(ct);

                counterDefinition.CounterTransactionId = counter.Id;
                counter.CounterTransactionId = counterDefinition.Id;

                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(counter);
                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(counterDefinition);
                await unitOfWork.SaveAsync(ct);
            }
        }
    }
}
