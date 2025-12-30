using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Queries.CheckSoftDuplicate
{
    public class CheckSoftDuplicateQueryHandler : BaseHandler, IRequestHandler<CheckSoftDuplicateQueryRequest, ResponseDto<CheckSoftDuplicateQueryResponse>>
    {
        public CheckSoftDuplicateQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CheckSoftDuplicateQueryResponse>> Handle(CheckSoftDuplicateQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Account>().FindAsync(x => !x.IsDeleted && x.AccountName == request.AccountName && x.Id != request.CurrentId);

            var map = mapper.Map<CheckSoftDuplicateQueryResponse, Account>(data);

            return new ResponseDto<CheckSoftDuplicateQueryResponse>().Success(map);
        }
    }
}
