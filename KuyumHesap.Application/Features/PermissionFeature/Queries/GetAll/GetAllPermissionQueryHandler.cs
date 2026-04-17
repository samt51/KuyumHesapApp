using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Queries.GetAll
{
    public class GetAllPermissionQueryHandler : BaseHandler, IRequestHandler<GetAllPermissionQueryRequest, ResponseDto<List<GetAllPermissionQueryResponse>>>
    {
        public GetAllPermissionQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllPermissionQueryResponse>>> Handle(GetAllPermissionQueryRequest request, CancellationToken cancellationToken)
        {
            var permissions = await unitOfWork.GetReadRepository<Permission>().GetAllAsync(
                x => !x.IsDeleted,
                orderBy: x => x.OrderBy(y => y.Code),
                ct: cancellationToken);

            var response = permissions.Select(x => new GetAllPermissionQueryResponse
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name
            }).ToList();

            return new ResponseDto<List<GetAllPermissionQueryResponse>>().Success(response);
        }
    }
}
