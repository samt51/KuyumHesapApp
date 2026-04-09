using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetById
{
    public class GetByIdRolesQueryHandler : BaseHandler, IRequestHandler<GetByIdRolesQueryRequest, ResponseDto<GetByIdRolesQueryResponse>>
    {
        public GetByIdRolesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdRolesQueryResponse>> Handle(GetByIdRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<KuyumHesap.Domain.Entities.Roles>().GetAsync(c => !c.IsDeleted && c.Id == request.Id);

            var map = mapper.Map<GetByIdRolesQueryResponse>(data);

            return new ResponseDto<GetByIdRolesQueryResponse>().Success(map);
        }
    }
}
