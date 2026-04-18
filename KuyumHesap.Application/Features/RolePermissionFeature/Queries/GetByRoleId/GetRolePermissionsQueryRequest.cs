using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.RolePermissionFeature.Queries.GetByRoleId
{
    public class GetRolePermissionsQueryRequest : IRequest<ResponseDto<List<GetRolePermissionsQueryResponse>>>
    {
        public int RoleId { get; set; }

        public GetRolePermissionsQueryRequest(int roleId)
        {
            RoleId = roleId;
        }
    }
}
