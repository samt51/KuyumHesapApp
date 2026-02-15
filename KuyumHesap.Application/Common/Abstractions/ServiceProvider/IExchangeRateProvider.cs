using KuyumHesap.Domain.Entities;

namespace KuyumHesap.Application.Common.Abstractions.ServiceProvider
{
    public record RateItem(string Code, decimal Buy, decimal Sell, DateTime RateDate);

    public interface IExchangeRateProvider
    {
        Task FetchRatesAsync(CancellationToken ct = default);
    }
}
