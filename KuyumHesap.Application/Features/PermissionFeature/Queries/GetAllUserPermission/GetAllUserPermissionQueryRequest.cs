using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Queries.GetAllUserPermission
{
    public class GetAllUserPermissionQueryRequest : IRequest<ResponseDto<List<GetAllUserPermissionQueryResponse>>>
    {
    }
}
