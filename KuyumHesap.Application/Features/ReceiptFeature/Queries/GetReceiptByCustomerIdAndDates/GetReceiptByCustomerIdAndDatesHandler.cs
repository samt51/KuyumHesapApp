using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetReceiptByCustomerIdAndDates
{
    public class GetReceiptByCustomerIdAndDatesHandler : BaseHandler, IRequestHandler<GetReceiptByCustomerIdAndDatesRequest, ResponseDto<List<GetReceiptByCustomerIdAndDatesResponse>>>
    {
        public GetReceiptByCustomerIdAndDatesHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetReceiptByCustomerIdAndDatesResponse>>> Handle(GetReceiptByCustomerIdAndDatesRequest request, CancellationToken cancellationToken)
        {
            var receipts = await unitOfWork
                .GetReadRepository<Receipt>()
                .GetAllAsync(
                    predicate: x => !x.IsDeleted
                                   && x.AccountId == request.CustomerId
                                   && x.ReceiptDate >= request.StartDate
                                   && x.ReceiptDate <= request.EndDate,
                    include: r => r
                        .Include(rc => rc.Account).ThenInclude(a => a.AccountType) // include account type for receipt.Account
                        .Include(rc => rc.Movements).ThenInclude(m => m.Account).ThenInclude(a => a.AccountType) // include movement.account.accountType
                        .Include(rc => rc.Movements).ThenInclude(m => m.TransactionType),
                    enableTracking: false,
                    ct: cancellationToken
                );

            // Use the Map<TDest, TSrc> overload that matches your IMapper signature explicitly
            var mapped = mapper.Map<List<GetReceiptByCustomerIdAndDatesResponse>, List<Receipt>>(receipts?.ToList() ?? new List<Receipt>());

            return new ResponseDto<List<GetReceiptByCustomerIdAndDatesResponse>>().Success(mapped);
        }
    }
}