using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetStockReport
{
    public class GetStockReportQueryRequest : IRequest<ResponseDto<GetStockReportQueryResponse>>
    {
        public int StockGroupAccounId { get; set; }
        public GetStockReportQueryRequest(int stockGroupAccounId)
        {
            this.StockGroupAccounId = stockGroupAccounId;
        }
    }
}
