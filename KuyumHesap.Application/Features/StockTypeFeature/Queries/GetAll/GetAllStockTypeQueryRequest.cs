using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockTypeFeature.Queries.GetAll
{
    public class GetAllStockTypeQueryRequest : IRequest<ResponseDto<List<GetAllStockTypeQueryResponse>>>
    {
    }
}
