using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport
{
    public class GetCashReportQueryRequest : IRequest<ResponseDto<GetCashReportQueryResponse>>
    {
        public int AccountId { get; set; }
        public GetCashReportQueryRequest(int accountId)
        {
            this.AccountId = accountId;
        }
    }
}
