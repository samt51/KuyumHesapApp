using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetAll
{
    public class GetAllReceiptQueryHandler : BaseHandler, IRequestHandler<GetAllReceiptQueryRequest, ResponseDto<List<GetAllReceiptQueryResponse>>>
    {
        public GetAllReceiptQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllReceiptQueryResponse>>> Handle(
       GetAllReceiptQueryRequest request,
       CancellationToken cancellationToken)
        {
            // get receipts with navigation properties included
            var receipts = await unitOfWork.GetReadRepository<Receipt>().GetAllAsync(
                x => !x.IsDeleted
                     && x.AccountId == request.AccountId
                     && x.IsCustomerReceipt == request.IsCari
                     && x.ReceiptDate >= request.StartDate
                     && x.ReceiptDate <= request.EndDate,
                include: q => q
                    .Include(r => r.Account)
                        .ThenInclude(a => a.AccountType)
                    .Include(r => r.Movements)
                        .ThenInclude(m => m.Account)
                            .ThenInclude(a => a.AccountType)
                    .Include(r => r.Movements)
                        .ThenInclude(m => m.TransactionType),
                orderBy: q => q.OrderByDescending(r => r.ReceiptDate),
                enableTracking: false,
                ct: cancellationToken);

            // ensure non-null list
            receipts = receipts ?? new List<Receipt>();

            // map list of receipts to list of response DTOs
            var mapped = mapper.Map<GetAllReceiptQueryResponse, Receipt>(receipts);

            return new ResponseDto<List<GetAllReceiptQueryResponse>>().Success(mapped);
        }

    }
}