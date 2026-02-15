using KuyumHesap.Application.Common.Abstractions.ServiceProvider;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace KuyumHesap.Infrastructure.Services
{
    public class PusulaExchangeRateProvider : IExchangeRateProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "CURRENCIES_CACHE";
        public PusulaExchangeRateProvider(IHttpClientFactory httpClientFactory, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task FetchRatesAsync(CancellationToken ct = default)
        {
            var currencies = new List<Currency>();
            var client = _httpClientFactory.CreateClient("CureClient");
            var json = await client.GetStringAsync("https://pusulanet.net/kurlar/pusula.txt", ct);

            var root = JsonSerializer.Deserialize<DailyCureDataDto.Root>(json);
            var data = root?.data ?? throw new Exception("Kur datası boş.");

            if (_cache.TryGetValue(CacheKey, out List<Currency> currency))
            {
                currencies = currency;
            }
            else
            {
                var currencyData = await _unitOfWork.GetReadRepository<Currency>().GetAllAsync();

                currencies = currencyData.ToList();

                _cache.Set(CacheKey, currencies, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(12)
                });
            }

            // Burada DB'ye yazmak istediğin kodları seç
            // Örn: TRY bazlılar
            var items = new List<ExchangeRate>();

            void Add(DateTime rateDate, int currencyId, decimal buyRate, decimal sellRate, decimal? previosCloseRate)
            {

                items.Add(new ExchangeRate(rateDate, currencyId, buyRate, sellRate, previosCloseRate));
            }

            Add(Convert.ToDateTime(data.ALTIN.tarih), 1, Convert.ToDecimal(data.ALTIN.satis), Convert.ToDecimal(data.ALTIN.alis), 0);
            Add(Convert.ToDateTime(data.USDTRY.tarih), 2, Convert.ToDecimal(data.USDTRY.satis), Convert.ToDecimal(data.USDTRY.alis), 0);
            Add(Convert.ToDateTime(data.EURTRY.tarih), 4, Convert.ToDecimal(data.EURTRY.satis), Convert.ToDecimal(data.EURTRY.alis), 0);
            Add(Convert.ToDateTime(data.CHFTRY.tarih), 5, Convert.ToDecimal(data.CHFTRY.satis), Convert.ToDecimal(data.CHFTRY.alis), 0);
            Add(Convert.ToDateTime(data.SARTRY.tarih), 6, Convert.ToDecimal(data.SARTRY.satis), Convert.ToDecimal(data.SARTRY.alis), 0);
            Add(Convert.ToDateTime(data.GUMUSTRY.tarih), 7, Convert.ToDecimal(data.GUMUSTRY.satis), Convert.ToDecimal(data.GUMUSTRY.alis), 0);

            await _unitOfWork.OpenTransactionAsync(ct);

            await _unitOfWork.GetWriteRepository<ExchangeRate>().AddRangeAsync(items);

            await _unitOfWork.SaveAsync(ct);

            await _unitOfWork.CommitAsync(ct);
        }
    }
}