using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport
{
    public class GetCashReportQueryRequest : IRequest<ResponseDto<GetCashReportQueryResponse>>
    {
    }
}
