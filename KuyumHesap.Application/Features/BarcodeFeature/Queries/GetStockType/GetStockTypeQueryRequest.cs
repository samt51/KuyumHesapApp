using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockType
{
    public class GetStockTypeQueryRequest : IRequest<ResponseDto<List<GetStockTypeQueryResponse>>>
    {
        public List<int> StockGroupId { get; set; }
        public GetStockTypeQueryRequest(List<int> stockGroupId)
        {
            this.StockGroupId = stockGroupId;
        }
    }
}
