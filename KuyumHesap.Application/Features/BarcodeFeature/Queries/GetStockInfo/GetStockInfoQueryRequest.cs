using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockInfo
{
    public class GetStockInfoQueryRequest : IRequest<ResponseDto<GetStockInfoQueryResponse>>
    {
        public int StockId { get; set; }
        public GetStockInfoQueryRequest(int stockId)
        {
            this.StockId = stockId;
        }
    }
}
