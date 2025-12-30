using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock
{
    public class GetStockGroupQueryRequest : IRequest<ResponseDto<List<GetStockGroupQueryResponse>>>
    {
    }
}
