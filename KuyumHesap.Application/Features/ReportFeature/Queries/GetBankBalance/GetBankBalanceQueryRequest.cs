using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetBankBalance
{
    public class GetBankBalanceQueryRequest : IRequest<ResponseDto<GetBankBalanceQueryResponse>>
    {
        public GetBankBalanceQueryRequest()
        {
            
        }
    }
}
