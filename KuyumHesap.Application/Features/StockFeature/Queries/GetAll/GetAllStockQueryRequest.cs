using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockFeature.Queries.GetAll
{
    public class GetAllStockQueryRequest : IRequest<ResponseDto<List<GetAllStockQueryResponse>>>
    {
    }
}
