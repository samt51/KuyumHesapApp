using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Queries.GetAll
{
    public class GetAllPageActionQueryRequest : IRequest<ResponseDto<List<GetAllPageActionQueryResponse>>>
    {
    }
}
