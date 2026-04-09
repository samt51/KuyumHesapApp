using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetAll
{
    public class GetAllRolesQueryHandler : BaseHandler, IRequestHandler<GetAllRolesQueryRequest, ResponseDto<List<GetAllRolesQueryResponse>>>
    {
        public GetAllRolesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllRolesQueryResponse>>> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<KuyumHesap.Domain.Entities.Roles>().GetAllAsync(c => !c.IsDeleted);

            var mapData = mapper.Map<List<GetAllRolesQueryResponse>>(data);

            return new ResponseDto<List<GetAllRolesQueryResponse>>().Success(mapData);
        }
    }
}
