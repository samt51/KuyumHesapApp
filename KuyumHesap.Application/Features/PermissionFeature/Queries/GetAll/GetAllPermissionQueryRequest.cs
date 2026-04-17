using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Queries.GetAll
{
    public class GetAllPermissionQueryRequest : IRequest<ResponseDto<List<GetAllPermissionQueryResponse>>>
    {
    }
}
