using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetFilterTypes
{
    public class GetFilterTypesQueryRequest : IRequest<ResponseDto<List<GetFilterTypesQueryResponse>>>
    {
    }
}
