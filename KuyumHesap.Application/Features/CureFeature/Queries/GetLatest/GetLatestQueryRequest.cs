using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.CureFeature.Queries.GetLatest
{
    public class GetLatestQueryRequest : IRequest<ResponseDto<List<GetLatestQueryResponse>>>
    {
    }
}
