using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserPermissionFeature.Queries.GetByUserId
{
    public class GetUserPermissionsQueryRequest : IRequest<ResponseDto<List<GetUserPermissionsQueryResponse>>>
    {
        public int UserId { get; set; }

        public GetUserPermissionsQueryRequest(int userId)
        {
            UserId = userId;
        }
    }
}
