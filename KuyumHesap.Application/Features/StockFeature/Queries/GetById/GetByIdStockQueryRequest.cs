using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockFeature.Queries.GetById
{
    public class GetByIdStockQueryRequest : IRequest<ResponseDto<GetByIdStockQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdStockQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
