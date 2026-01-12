using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Queries.GetById
{
    public class GetByIdExchangeQueryRequest : IRequest<ResponseDto<GetByIdExchangeQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdExchangeQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
