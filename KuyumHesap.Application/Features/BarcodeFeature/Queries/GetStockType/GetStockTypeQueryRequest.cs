using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockType
{
    public class GetStockTypeQueryRequest :IRequest<ResponseDto<List<GetStockTypeQueryResponse>>>
    {
        public int StockGroupId { get; set; }
        public GetStockTypeQueryRequest(int stockGroupId)
        {
            this.StockGroupId = stockGroupId;
        }
    }
}
