using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Domain.Entities;
using KuyumHesap.Infrastructure.Services.Abstract;
using System.Text.Json;

namespace KuyumHesap.Infrastructure.Services.Concrete
{
    public class KurGuncellemeService : IKurGuncellemeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public KurGuncellemeService(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> HariciAPIdenKurlariGuncelle()
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.Timeout = TimeSpan.FromSeconds(10); // Timeout ekle

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

            var sistemDovizleri = await _unitOfWork.GetReadRepository<Currency>().GetAllAsync(x => !x.IsDeleted);
            int guncellenenKurSayisi = 0;
            var bugununTarihi = DateTime.Today;

            await _unitOfWork.OpenTransactionAsync();
            foreach (var doviz in sistemDovizleri)
            {
                if (string.IsNullOrEmpty(doviz.MetaCode) || !haremData.TryGetProperty(doviz.MetaCode, out var kurData))
                {
                    continue;
                }

                if (!kurData.TryGetProperty("alis", out var alisElement) ||
                    !kurData.TryGetProperty("satis", out var satisElement))
                {
                    continue;
                }

                var alisStr = alisElement.ToString().Replace('.', ',');
                var satisStr = satisElement.ToString().Replace('.', ',');

                if (decimal.TryParse(alisStr, out var alisKuru) &&
                    decimal.TryParse(satisStr, out var satisKuru))
                {
                    var yeniKur = new ExchangeRate
                    {
                        RateDate = bugununTarihi,
                        Id = doviz.Id,
                        BuyRate = alisKuru,
                        SellRate = satisKuru,
                    };
                    await _unitOfWork.GetWriteRepository<ExchangeRate>().AddAsync(yeniKur);

                    guncellenenKurSayisi++;
                }
            }

            // TRY kurunu güncelle
            var tryDoviz = sistemDovizleri.FirstOrDefault(d => d.CurrencyCode.Equals("TRY", StringComparison.OrdinalIgnoreCase));
            if (tryDoviz != null)
            {
                var tryKur = new ExchangeRate
                {
                    RateDate = bugununTarihi,
                    Id = tryDoviz.Id,
                    BuyRate = 1.0000m,
                    SellRate = 1.0000m,
                };
                await _unitOfWork.GetWriteRepository<ExchangeRate>().AddAsync(tryKur);
            }
            await _unitOfWork.SaveAsync();
            await _unitOfWork.CommitAsync();

            return $"✓ Kurlar ve Veriler güncellendi.";

        }

        public async Task<string> KurlariGuncelle()
        {
            return await HariciAPIdenKurlariGuncelle();
        }

        public async Task<string> KurlariHazirlaVeGuncelle()
        {
            var sonuclar = new List<string>();
            var bugununTarihi = DateTime.Today;

            // 1. Önce bugünün kurları var mı kontrol et
            var dailyCure = await _unitOfWork.GetReadRepository<ExchangeRate>().GetAllAsync(r => r.RateDate == bugununTarihi);

            if (!dailyCure.Any())
            {
                // Bugünün kurları yoksa, en son kur tarihini bul
                var enSonKurTarihi = await _unitOfWork.GetReadRepository<ExchangeRate>().GetAllAsync(x => !x.IsDeleted, orderBy: y => y.OrderByDescending(c => c.RateDate));

                var ensonKurTarihiValue = enSonKurTarihi.FirstOrDefault()?.RateDate;

                if (ensonKurTarihiValue.HasValue)
                {
                    // En son kurları bugüne kopyala
                    var kopyalananSayisi = await CopyRatesToTodayAsync(ensonKurTarihiValue.Value, CancellationToken.None);
                    await _unitOfWork.CommitAsync();
                    sonuclar.Add($"✓ Kur çekilemedi. {ensonKurTarihiValue.Value:dd.MM.yyyy} tarihli kurlar bugüne kopyalandı.");
                }
                else
                {
                    sonuclar.Add("⚠ Veritabanında hiç kur kaydı bulunamadı.");
                }
            }
            else
            {
                sonuclar.Add($"");
            }

            // 2. Harici API'den güncelleme dene
            var apiSonuc = await HariciAPIdenKurlariGuncelle();
            sonuclar.Add(apiSonuc);

            return string.Join(" ", sonuclar);
        }
        public async Task<int> CopyRatesToTodayAsync(DateTime sourceDate, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;
            var srcDate = sourceDate.Date;

            // 1) Kaynak günün kurlarını çek
            var sourceRates = await _unitOfWork.GetReadRepository<ExchangeRate>()
                .GetAllAsync(x => x.RateDate == srcDate);

            if (!sourceRates.Any())
                return 0;

            // 2) Bugünün kurlarını çek (aynı KurID'ler için)
            var sourceIds = sourceRates.Select(x => x.ExchangeRateId).ToList();

            var todayRates = await _unitOfWork.GetReadRepository<ExchangeRate>()
                .GetAllAsync(x => x.RateDate == today && sourceIds.Contains(x.ExchangeRateId));

            // 3) Lookup (KurID -> entity)
            var todayLookup = todayRates.ToDictionary(x => x.ExchangeRateId);

            // 4) Upsert
            foreach (var src in sourceRates)
            {
                if (todayLookup.TryGetValue(src.ExchangeRateId, out var existing))
                {
                    // MATCHED -> UPDATE
                    existing.BuyRate = src.BuyRate;
                    existing.SellRate = src.SellRate;

                    await _unitOfWork.GetWriteRepository<ExchangeRate>().UpdateAsync(existing);
                }
                else
                {
                    // NOT MATCHED -> INSERT
                    var newRow = new ExchangeRate
                    {
                        RateDate = today,
                        ExchangeRateId = src.ExchangeRateId,
                        BuyRate = src.BuyRate,
                        SellRate = src.SellRate,
                        PreviousCloseRate = null // istersen doldur
                    };

                    await _unitOfWork.GetWriteRepository<ExchangeRate>().AddAsync(newRow, cancellationToken);
                }
            }

            // 5) Save
            return await _unitOfWork.SaveAsync(cancellationToken);
        }

    }
}
