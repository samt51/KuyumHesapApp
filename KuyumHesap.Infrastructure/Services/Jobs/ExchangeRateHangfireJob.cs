using KuyumHesap.Application.Common.Abstractions.ServiceProvider;

namespace KuyumHesap.Infrastructure.Services.Jobs
{
    public class ExchangeRateHangfireJob
    {
        private readonly IRefreshExchangeRatesUseCase _useCase;

        public ExchangeRateHangfireJob(IRefreshExchangeRatesUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task Run()
        {
            await _useCase.ExecuteAsync();
        }
    }
}