
using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Feature.AccountFeature.Queries.GetAllAccountByTypeId
{
    public class GetAllAccountByTypeIdQueryHandler : BaseHandler, IRequestHandler<GetAllAccountByTypeIdQueryRequest, ResponseDto<List<GetAllAccountByTypeIdQueryResponse>>>
    {
        public GetAllAccountByTypeIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllAccountByTypeIdQueryResponse>>> Handle(GetAllAccountByTypeIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Account>().GetAllAsync(c => c.AccountTypeId == request.AccountTypeId);

            var response = new List<GetAllAccountByTypeIdQueryResponse>();

            foreach (var item in data)
            {
                response.Add(new GetAllAccountByTypeIdQueryResponse
                {
                    AccountId = item.Id,
                    AccountName = item.AccountName,
                    IsActive = item.IsActive,
                    AccountTypeId = item.AccountTypeId,
                    AccountTypeName = item.AccountType?.AccountTypeName ?? string.Empty,
                    Tezgahtar = item.IsCashier
                });
            }

            return new ResponseDto<List<GetAllAccountByTypeIdQueryResponse>>().Success(response);
        }
    }
}
