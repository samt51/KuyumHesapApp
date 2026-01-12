using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Queries.GetAll
{
    public class GetAllUserQueryRequest : IRequest<ResponseDto<List<GetAllUserQueryResponse>>>
    {
    }
}
