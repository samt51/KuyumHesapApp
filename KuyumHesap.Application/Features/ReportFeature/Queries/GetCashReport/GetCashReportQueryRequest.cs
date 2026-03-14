using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport
{
    public class GetCashReportQueryRequest : IRequest<ResponseDto<CashReportModelResponseDto>>
    {
        public int? AccountId { get; set; }
        public string AccountTypeName { get; set; }
        public GetCashReportQueryRequest(int? accountId)
        {
            this.AccountId = accountId;
        }
    }
}
