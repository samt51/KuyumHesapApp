using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetBankReport
{
    public class GetBankReportQueryRequest : IRequest<ResponseDto<GetBankReportQueryResponse>>
    {
      
    }
}
