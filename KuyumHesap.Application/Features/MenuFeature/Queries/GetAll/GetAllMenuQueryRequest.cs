using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Queries.GetAll
{
    public class GetAllMenuQueryRequest : IRequest<ResponseDto<List<GetAllMenuQueryResponse>>>
    {
    }
}
