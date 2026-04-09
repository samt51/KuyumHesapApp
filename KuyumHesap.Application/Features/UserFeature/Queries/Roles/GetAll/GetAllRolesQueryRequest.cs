using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetAll
{
    public class GetAllRolesQueryRequest : IRequest<ResponseDto<List<GetAllRolesQueryResponse>>>
    {
    }
}
