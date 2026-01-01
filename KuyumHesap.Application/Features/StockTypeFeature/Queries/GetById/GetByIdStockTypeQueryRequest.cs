using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockTypeFeature.Queries.GetById
{
    public class GetByIdStockTypeQueryRequest : IRequest<ResponseDto<GetByIdStockTypeQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdStockTypeQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
