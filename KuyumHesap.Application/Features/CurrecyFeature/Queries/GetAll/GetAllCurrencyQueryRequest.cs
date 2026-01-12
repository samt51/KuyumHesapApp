using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.CurrecyFeature.Queries.GetAll
{
    public class GetAllCurrencyQueryRequest : IRequest<ResponseDto<List<GetAllCurrencyQueryResponse>>>
    {
        public int Id { get; set; }
        public string StockGroupName { get; set; } = null!;
    }
}
