using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock
{
    public class GetStockQueryRequest : IRequest<ResponseDto<List<GetStockQueryResponse>>>
    {
        public int StockTypeId { get; set; }
        public GetStockQueryRequest(int stockTypeId)
        {
            this.StockTypeId = stockTypeId;
        }
    }
}
