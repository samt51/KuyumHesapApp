using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetBankReport
{
    public class GetBankReportQueryRequest : IRequest<ResponseDto<GetBankReportQueryResponse>>
    {
        public int AccountId { get; set; }
        public GetBankReportQueryRequest(int accoundId)
        {
            this.AccountId = accoundId; 
        }
    }
}
