using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetPosReport
{
    public class GetPosReportQueryRequest : IRequest<ResponseDto<GetPosReportQueryResponse>>    
    {
        public int AccountId { get; set; }
        public GetPosReportQueryRequest(int accountId)
        {
            this.AccountId = accountId; 
        }
    }
}
