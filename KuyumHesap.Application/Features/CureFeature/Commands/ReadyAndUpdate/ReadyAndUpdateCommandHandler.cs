using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using KuyumHesap.Infrastructure.Services.Abstract;
using MediatR;
using System.Net.WebSockets;
using System.Text.Json;

namespace KuyumHesap.Application.Features.CureFeature.Commands.ReadyAndUpdate
{
    public class ReadyAndUpdateCommandHandler : BaseHandler, IRequestHandler<ReadyAndUpdateCommandRequest, ResponseDto<ReadyAndUpdateCommandResponse>>
    {
        private readonly IKurGuncellemeService _kurGuncellemeService;
        public ReadyAndUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IKurGuncellemeService kurGuncellemeService) : base(mapper, unitOfWork)
        {
            _kurGuncellemeService = kurGuncellemeService;
        }

        public async Task<ResponseDto<ReadyAndUpdateCommandResponse>> Handle(ReadyAndUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<ExchangeRate>().GetAllAsync(x => !x.IsDeleted && x.RateDate == DateTime.Today);

            if (!data.Any())
            {
                var getLastCureDate = await unitOfWork.GetReadRepository<ExchangeRate>().GetAsync(x => !x.IsDeleted, orderBy: y => y.OrderByDescending(x => x.RateDate));

                await CopyRatesToTodayAsync(getLastCureDate.RateDate, cancellationToken);

                return new ResponseDto<ReadyAndUpdateCommandResponse>().Fail("Bugünün kurları bulunamadı. Son kur tarihi baz alınarak kurlar güncellendi.", 200);
            }
            var cureData = await _kurGuncellemeService.HariciAPIdenKurlariGuncelle();
            if (!JsonDocument.Parse(cureData).RootElement.TryGetProperty("data", out var haremData))
            {
                throw new Exception
                    ("⚠ API'den gelen veri formatı hatalı, mevcut kurlar kullanılıyor.");
            }

            var cureList = await unitOfWork.GetReadRepository<Currency>().GetAllAsync(x => !x.IsDeleted);
            var exchangeRateListData = new List<ExchangeRate>();
            foreach (var cure in cureList)
            {
                if (string.IsNullOrEmpty(cure.MetaCode) || !haremData.TryGetProperty(cure.MetaCode, out var kurData))
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
                    exchangeRateListData.Add(new ExchangeRate
                    {
                        RateDate = DateTime.Today,
                        ExchangeRateId = cure.Id,
                        BuyRate =alisKuru ,
                        SellRate = satisKuru
                    });
                }
                if (!exchangeRateListData.Any())
                {
                    await UpsertRateAsync(exchangeRateListData, cancellationToken);
                }

            }
            var tryDoviz = cureList.FirstOrDefault(d => d.CurrencyCode.Equals("TRY", StringComparison.OrdinalIgnoreCase));
            if (tryDoviz != null)
            {
                var tryKurList = new List<ExchangeRate>();
                tryKurList.Add(new ExchangeRate
                {
                    RateDate = DateTime.Today,
                    ExchangeRateId = tryDoviz.Id,
                    BuyRate = 1.0000m,
                    SellRate = 1.0000m,
                });
                await UpsertRateAsync(tryKurList, cancellationToken);
            }

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<ReadyAndUpdateCommandResponse>().Success();


        }
        public async Task CopyRatesToTodayAsync(DateTime kaynakTarih, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;
            var sourceDate = kaynakTarih.Date;

            // Kaynak günün kurlarını çek
            var sourceRates = await unitOfWork.GetReadRepository<ExchangeRate>()
                .GetAllAsync(x => x.RateDate == sourceDate);

            if (!sourceRates.Any())
                return;

            var currencyIds = sourceRates.Select(x => x.Id).ToList();

            // Bugün aynı currencyId'lere ait kurlar var mı çek
            var todayRates = await unitOfWork.GetReadRepository<ExchangeRate>()
                .GetAllAsync(x => x.RateDate == today && currencyIds.Contains(x.Id));

            var todayLookup = todayRates.ToDictionary(x => x.Id);

            foreach (var src in sourceRates)
            {
                if (todayLookup.TryGetValue(src.Id, out var existing))
                {
                    // MATCHED -> UPDATE
                    existing.BuyRate = src.BuyRate;
                    existing.SellRate = src.SellRate;

                    await unitOfWork.GetWriteRepository<ExchangeRate>().UpdateAsync(existing);
                }
                else
                {
                    // NOT MATCHED -> INSERT
                    await unitOfWork.GetWriteRepository<ExchangeRate>().AddAsync(new ExchangeRate
                    {
                        RateDate = today,
                        Id = src.Id,
                        BuyRate = src.BuyRate,
                        SellRate = src.SellRate
                    }, cancellationToken);
                }
            }

            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

        }
        public async Task UpsertRateAsync(List<ExchangeRate> exchangeRates, CancellationToken ct)
        {
            foreach (var item in exchangeRates)
            {


                // (target.Tarih = @Tarih AND target.KurID = @KurID) -> kaydı bul
                var existing = await unitOfWork.GetReadRepository<ExchangeRate>()
                    .GetAsync(x => x.RateDate == DateTime.Today && x.Id == item.Id);

                if (existing is not null)
                {
                    // WHEN MATCHED THEN UPDATE
                    existing.BuyRate = item.BuyRate;
                    existing.SellRate = item.SellRate;

                    await unitOfWork.GetWriteRepository<ExchangeRate>().UpdateAsync(existing, ct);
                }
                else
                {
                    // WHEN NOT MATCHED THEN INSERT
                    await unitOfWork.GetWriteRepository<ExchangeRate>().AddAsync(new ExchangeRate
                    {
                        RateDate = DateTime.Today,
                        ExchangeRateId = item.Id,
                        BuyRate = item.BuyRate,
                        SellRate = item.SellRate
                    }, ct);
                }

                await unitOfWork.SaveAsync(ct);
            }
            ;
        }
    }
}
