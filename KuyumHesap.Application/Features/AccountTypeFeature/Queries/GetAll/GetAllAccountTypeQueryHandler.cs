using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetAll
{
    public class GetAllAccountTypeQueryHandler : BaseHandler, IRequestHandler<GetAllAccountTypeQueryRequest, ResponseDto<List<GetAllAccountTypeQueryResponse>>>
    {
        public GetAllAccountTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllAccountTypeQueryResponse>>> Handle(GetAllAccountTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<AccountType>().GetAllAsync(x => !x.IsDeleted);

            var map = mapper.Map<GetAllAccountTypeQueryResponse, AccountType>(data);

            map = map.OrderByDescending(x => x.BalanceOrder).ToList();

            return new ResponseDto<List<GetAllAccountTypeQueryResponse>>().Success(map);
        }
    }
}
