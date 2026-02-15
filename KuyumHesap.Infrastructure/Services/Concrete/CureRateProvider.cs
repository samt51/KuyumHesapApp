using KuyumHesap.Infrastructure.Services.Abstract;

namespace KuyumHesap.Infrastructure.Services.Concrete
{
    public class CureRateProvider : ICureRateProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CureRateProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> FetchRawJsonAsync(CancellationToken ct = default)
        {
            var client = _httpClientFactory.CreateClient("CureClient");
            var response = await client.GetAsync("https://pusulanet.net/kurlar/pusula.txt", ct);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Harici API'ye ulaşılamadı.");

            return await response.Content.ReadAsStringAsync(ct);
        }
    }
}
