using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetAllReports
{
    public class GetAllReportQueryRequest : IRequest<ResponseDto<GetAllReportQueryResponse>>
    {
        public int? AccountId { get; set; }
        public GetAllReportQueryRequest(int? accountId)
        {
            this.AccountId = accountId;
        }
    }
}
