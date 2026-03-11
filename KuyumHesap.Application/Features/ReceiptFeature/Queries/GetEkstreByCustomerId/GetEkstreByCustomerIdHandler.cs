using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.MovementFeature.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId
{
    public class GetEkstreByCustomerIdHandler : BaseHandler, IRequestHandler<GetEkstreByCustomerIdRequest, ResponseDto<List<GetEkstreByCustomerIdResponse>>>
    {
        public GetEkstreByCustomerIdHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetEkstreByCustomerIdResponse>>> Handle(GetEkstreByCustomerIdRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.GetReadRepository<Account>().GetAsync(x => !x.IsDeleted && x.Id == request.CustomerId);

            var data = await unitOfWork
      .GetReadRepository<Receipt>()
      .GetAllAsync(
          predicate: x =>
              !x.IsDeleted &&
              x.AccountId == request.CustomerId &&
              x.ReceiptDate >= request.StartDate &&
              x.ReceiptDate <= request.EndDate,
          include: q => q
              .Include(r => r.Account)
                  .ThenInclude(a => a.AccountType)
              .Include(r => r.Movements)
                  .ThenInclude(m => m.TransactionType));

            var currency = await unitOfWork.GetReadRepository<Currency>().GetAllAsync(x => !x.IsDeleted);

            var rsp = new List<GetEkstreByCustomerIdResponse>();
            foreach (var item in data)
            {
                var listData = new List<GetMovementByCustomerIdResponse>();
                var receiptData = new List<GetEkstreByCustomerIdResponse>();
                var entityData = new GetEkstreByCustomerIdResponse
                {

                    Id = item.Id,
                    AccountId = item.AccountId,
                    AccountName = item.Account.AccountName,
                    AccountTypeName = item.Account.AccountType.AccountTypeName,
                    ReceiptDate = item.ReceiptDate,
                    CurrencyCode = item.CurrencyCode,
                    Description = item.Description,
                    EmployeeId = item.EmployeeId,
                    IsCustomerReceipt = item.IsCustomerReceipt,
                    OpenBalanceAmount = item.OpenBalanceAmount,
                    ReceiptNumber = item.ReceiptNumber,
                };
                foreach (var movement in item.Movements)
                {
                    listData.Add(new()
                    {

                        Id = movement.Id,
                        AccountId = movement.AccountId,
                        TransactionTypeId = movement.TransactionTypeId,
                        TransactionName = movement.TransactionType.TransactionName,
                        TransactionCode = movement.TransactionType.TransactionCode,
                        StockId = movement.StockId,
                        Description = movement.Description,
                        ForeignCurrencyAmount = movement.ForeignCurrencyAmount,
                        ForeignCurrencyId = movement.ForeignCurrencyId,
                        ForeignCurrencyCode = currency.FirstOrDefault(c => c.Id == movement.ForeignCurrencyId)?.CurrencyCode ?? "",
                        ForeignExchangeRate = movement.ForeignExchangeRate,
                        CounterCurrencyAmount = movement.CounterCurrencyAmount,
                        CounterCurrencyId = movement.CounterCurrencyId,
                        CounterCurrencyCode = currency.FirstOrDefault(c => c.Id == movement.CounterCurrencyId)?.CurrencyCode ?? "",
                        CounterExchangeRate = movement.CounterExchangeRate,
                        BaseCurrencyAmount = movement.BaseCurrencyAmount,
                        CostAmount = movement.CostAmount,
                        ProfitAmount = movement.ProfitAmount,
                        CounterTransactionId = movement.CounterTransactionId,
                        Quantity = movement.Quantity,
                        MillRate = movement.MillRate,
                        LaborCost = movement.LaborCost,
                        ReceiptId = movement.ReceiptId,
                        IsLaborIncluded = movement.IsLaborIncluded,
                        IsReconciled = movement.IsReconciled,
                        LaborQuantity = movement.LaborQuantity,
                        LaborUnit = movement.LaborUnit,
                        NetProductValue = movement.NetProductValue,
                        TotalLaborCost = movement.TotalLaborCost,
                    });
                }
                entityData.GetMovementByCustomerIdResponses = listData;
                rsp.Add(entityData);
            }
            return new ResponseDto<List<GetEkstreByCustomerIdResponse>>().Success(rsp);
        }

        public async Task<decimal> TotalAmount()
        {
            var toplamHas = 0;
            var hasKuruData = await unitOfWork.GetReadRepository<ExchangeRate>().FindAsync(k => k.CurrencyId == 1, orderBy: y => y.OrderByDescending(c => c.CreatedDate));
            var hasKuru = hasKuruData != null ? hasKuruData.BuyRate : 1;

            //for (const dovizKodu in bakiyeDurumu) {
            //    const bakiye = bakiyeDurumu[dovizKodu];
            //    if (dovizKodu === 'HAS')
            //    {
            //        toplamHas += bakiye;
            //    }
            //    else
            //    {
            //        const dovizKurData = allExchangeRates.find(k => k.dovizKodu === dovizKodu);
            //        const dovizKur = dovizKurData ? dovizKurData.alisKuru : 1;
            //        if (hasKuru > 0)
            //        {
            //            toplamHas += (bakiye * dovizKur) / hasKuru;
            //        }
            //    }
            //}

            return 4;
        }
    }
}
