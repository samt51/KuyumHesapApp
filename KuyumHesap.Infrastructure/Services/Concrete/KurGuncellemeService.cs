using KuyumHesap.Infrastructure.Services.Abstract;
using System.Text.Json;


namespace KuyumHesap.Infrastructure.Services.Concrete
{
    public class KurGuncellemeService : IKurGuncellemeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public KurGuncellemeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> HariciAPIdenKurlariGuncelle()
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.Timeout = TimeSpan.FromSeconds(10);

            var response = await httpClient.GetAsync("https://canlipiyasalar.haremaltin.com/tmp/doviz.json?dil_kodu=tr");

            if (!response.IsSuccessStatusCode)
            {
                return "⚠ Harici API'ye ulaşılamadı, mevcut kurlar kullanılıyor.";
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();

            if (!JsonDocument.Parse(jsonResponse).RootElement.TryGetProperty("data", out var haremData))
            {
                return "⚠ API'den gelen veri formatı hatalı, mevcut kurlar kullanılıyor.";
            }

            return jsonResponse;
        }
    }
}
