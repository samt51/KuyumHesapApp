using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetAccountStatement
{
    public class GetAccountStatementQueryRequest:IRequest<ResponseDto<GetAccountStatementQueryResponse>>
    {
        public int AccountId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
