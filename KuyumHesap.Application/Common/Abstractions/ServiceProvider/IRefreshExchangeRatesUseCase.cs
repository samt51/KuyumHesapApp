using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;

namespace KuyumHesap.Application.Common.Abstractions.ServiceProvider
{
    public interface IRefreshExchangeRatesUseCase
    {
        Task ExecuteAsync(CancellationToken ct = default);
    }

    public class RefreshExchangeRatesUseCase : IRefreshExchangeRatesUseCase
    {
        private readonly IExchangeRateProvider _provider;
        private readonly IUnitOfWork _unitOfWork;

        public RefreshExchangeRatesUseCase(IExchangeRateProvider provider, IUnitOfWork unitOfWork)
        {
            _provider = provider;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(CancellationToken ct = default)
        {
            await _provider.FetchRatesAsync(ct);
        }
    }
}
