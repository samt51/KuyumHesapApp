using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockGroupFeature.Queries.GetById
{
    public class GetByIdStockGroupQueryRequest : IRequest<ResponseDto<GetByIdStockGroupQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdStockGroupQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
