
using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.CureFeature.Queries.GetLatest
{
    public class GetLatestQueryHandler : BaseHandler, IRequestHandler<GetLatestQueryRequest, ResponseDto<List<GetLatestQueryResponse>>>
    {
        public GetLatestQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
        public async Task<ResponseDto<List<GetLatestQueryResponse>>> Handle(GetLatestQueryRequest request, CancellationToken cancellationToken)
        {
            // hedef tarih: dün (sadece tarih kısmı)
            var targetDate = DateTime.Today.AddDays(-1).Date;
            var endOfTarget = targetDate.AddDays(1); // exclusive upper bound

            // Currency'leri al (küçük liste olmalı)
            var currencies = await unitOfWork.GetReadRepository<Currency>().GetAllAsync(x => !x.IsDeleted, ct: cancellationToken);
            var currencyDict = currencies.ToDictionary(c => c.Id);

            // DB'den targetDate'e eşit veya ondan önceki tüm kayıtları getiriyoruz (saat bilgisi nedeniyle aralık kullanıyoruz)
            // Bu liste hafızaya alınacak; sonrasında her para birimi için en son (en güncel) kaydı seçiyoruz.
            var ratesQuery = await unitOfWork.GetReadRepository<ExchangeRate>()
                .GetAllQueryAsync(x => !x.IsDeleted && x.RateDate < endOfTarget);
            var ratesList = await ratesQuery.ToListAsync(cancellationToken);

            // Her CurrencyId için targetDate'e kadar (<= targetDate) olan en son kaydı seç
            var latestPerCurrency = ratesList
                .Where(r => r.RateDate < endOfTarget) // redundant guard, ama okunurluk için bırakıldı
                .GroupBy(r => r.CurrencyId)
                .Select(g => g.OrderByDescending(r => r.RateDate).First())
                .ToList();

            // Döviz tablosundaki sıraya göre (ve TRY hariç) her para birimi için tek bir kayıt döndür
            var result = currencies
                .Where(c => c.CurrencyCode != "TRY")
                .OrderBy(c => c.Id)
                .Select(c =>
                {
                    var rate = latestPerCurrency.FirstOrDefault(r => r.CurrencyId == c.Id);
                    if (rate == null) return null; // o para birimi için hiç tarihsel kayıt yoksa atla
                    return new GetLatestQueryResponse
                    {
                        CurrencyCode = c.CurrencyCode,
                        BuyRate = rate.BuyRate,
                        SellRate = rate.SellRate,
                        Id = rate.Id,
                        PreviousClosingRate = rate.PreviousCloseRate ?? 0m
                    };
                })
                .Where(x => x != null)!
                .ToList()!;

            return new ResponseDto<List<GetLatestQueryResponse>>().Success(result);
        }
    }
}