using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockGroupFeature.Queries.GetAll
{
    public class GetAllStockGroupQueryRequest: IRequest<ResponseDto<List<GetAllStockGroupQueryResponse>>>
    {
    }
}
