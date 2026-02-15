using KuyumHesap.Application.Common.Abstractions.Aut;
using KuyumHesap.Application.Common.Models;
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

        public async Task<DailyCureDataDto.Data> GetDailyCureData()
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.Timeout = TimeSpan.FromSeconds(10);

            var response = await httpClient.GetAsync("https://pusulanet.net/kurlar/pusula.txt");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("⚠ Harici API'ye ulaşılamadı, mevcut kurlar kullanılıyor.");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var jsonDeserilizerData = JsonSerializer.Deserialize<DailyCureDataDto.Root>(jsonResponse);

            return jsonDeserilizerData?.data ?? throw new Exception("⚠ Harici API'den geçerli veri alınamadı, mevcut kurlar kullanılıyor.");
        }
    }
}
