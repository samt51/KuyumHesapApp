using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.RolePermissionFeature.Queries.GetByRoleId
{
    public class GetRolePermissionsQueryHandler : BaseHandler, IRequestHandler<GetRolePermissionsQueryRequest, ResponseDto<List<GetRolePermissionsQueryResponse>>>
    {
        public GetRolePermissionsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetRolePermissionsQueryResponse>>> Handle(GetRolePermissionsQueryRequest request, CancellationToken cancellationToken)
        {
            var rolePermissions = await unitOfWork.GetReadRepository<RolePermission>().GetAllAsync(
                x => x.RoleId == request.RoleId && !x.IsDeleted,
                include: x => x.Include(y => y.Permission),
                ct: cancellationToken);

            var response = rolePermissions.Select(x => new GetRolePermissionsQueryResponse
            {
                Id = x.Id,
                RoleId = x.RoleId,
                PermissionId = x.PermissionId,
                PermissionCode = x.Permission?.Code ?? string.Empty,
                PermissionName = x.Permission?.Name ?? string.Empty
            }).ToList();

            return new ResponseDto<List<GetRolePermissionsQueryResponse>>().Success(response);
        }
    }
}
