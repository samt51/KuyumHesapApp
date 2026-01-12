using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.CurrecyFeature.Queries.GetById
{
    public class GetByIdCurrencyQueryRequest : IRequest<ResponseDto<GetByIdCurrencyQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdCurrencyQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
