using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetPacker;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetProductType;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockType;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetAllMain
{
    public class GetAllMainQueryResponse
    {
        public List<GetStockGroupQueryResponse> getStockGroupQueries { get; set; }
        public List<GetStockTypeQueryResponse> getStockTypeQueries { get; set; }
        public List<GetStockQueryResponse> getStockQueries { get; set; }
        public List<GetProductTypeQueryResponse> getProductTypeQueries { get; set; }
        public List<GetPackerQueryResponse> getPackerQueryResponses { get; set; }
    }
}
