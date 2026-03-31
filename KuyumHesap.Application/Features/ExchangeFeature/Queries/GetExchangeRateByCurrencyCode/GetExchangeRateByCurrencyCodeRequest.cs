using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Queries.GetExchangeRateByCurrencyCode
{
    public class GetExchangeRateByCurrencyCodeRequest : IRequest<ResponseDto<GetExchangeRateByCurrencyCodeResponse>>
    {
        public int CurrencyId { get; set; }
        public bool IsEntry { get; set; }
    }
}
