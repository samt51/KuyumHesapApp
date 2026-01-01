using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetPosBalance
{
    public class GetPosBalanceQueryRequest : IRequest<ResponseDto<GetPosBalanceQueryResponse>>
    {
    }
}
