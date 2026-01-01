using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport;
using KuyumHesap.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Persistence.Common.Concrete.SqlFunctions.AccountBalanceFunc
{
    public class AccountBalanceQuerySqlFunc : IAccountBalanceQuery
    {
        private readonly AppDbContext _context;

        public AccountBalanceQuerySqlFunc(AppDbContext context)
        {
            _context = context;
        }
        private sealed class DashboardRowDto
        {
            public string DovizKodu { get; set; } = null!;
            public decimal Devreden { get; set; }
            public decimal GunlukGiris { get; set; }
            public decimal GunlukCikis { get; set; }
            public decimal Bakiye { get; set; }
            public decimal HasKarsiligi { get; set; }
        }


        public async Task<KasaRaporuViewModelDto> GetAsync(string hesapTipiAdi, int? hesapId, CancellationToken ct)
        {
            var bugun = DateTime.Today;

            var sql = @"
SELECT 
    h.BakiyeBirimi AS DovizKodu,
    ISNULL(SUM(CASE 
        WHEN CAST(h.Tarih AS DATE) < {0} 
        THEN CASE WHEN h.GirisMi = 1 THEN h.BakiyeEtkiMiktari ELSE -h.BakiyeEtkiMiktari END 
        ELSE 0 
    END), 0) AS Devreden,

    ISNULL(SUM(CASE 
        WHEN CAST(h.Tarih AS DATE) = {0} AND h.GirisMi = 1 
        THEN h.BakiyeEtkiMiktari ELSE 0 
    END), 0) AS GunlukGiris,

    ISNULL(SUM(CASE 
        WHEN CAST(h.Tarih AS DATE) = {0} AND h.GirisMi = 0 
        THEN h.BakiyeEtkiMiktari ELSE 0 
    END), 0) AS GunlukCikis,

    ISNULL(SUM(CASE 
        WHEN CAST(h.Tarih AS DATE) <= {0} 
        THEN CASE WHEN h.GirisMi = 1 THEN h.BakiyeEtkiMiktari ELSE -h.BakiyeEtkiMiktari END 
        ELSE 0 
    END), 0) AS Bakiye,

    dbo.fn_KurCevir(
        {0}, 
        h.BakiyeBirimi, 
        'HAS',
        ISNULL(SUM(CASE 
            WHEN CAST(h.Tarih AS DATE) <= {0} 
            THEN CASE WHEN h.GirisMi = 1 THEN h.BakiyeEtkiMiktari ELSE -h.BakiyeEtkiMiktari END 
            ELSE 0 
        END), 0)
    ) AS HasKarsiligi
FROM vw_HesapEkstresi h
WHERE h.HesapTipiAdi = {1}
  AND ({2} IS NULL OR h.HesapID = {2})
GROUP BY h.BakiyeBirimi
ORDER BY h.BakiyeBirimi;
";

            var rows = await _context.Database
                .SqlQueryRaw<DashboardRowDto>(sql, bugun.Date, hesapTipiAdi, hesapId)
                .ToListAsync(ct);

            // ADO.NET kodundaki mapping + Math.Abs + toplam mantığı birebir
            var rapor = new KasaRaporuViewModelDto();

            decimal toplamHasOrijinal = 0m;

            foreach (var r in rows)
            {
                toplamHasOrijinal += r.HasKarsiligi;

                rapor.Detaylar.Add(new KasaDetayViewModel
                {
                    DovizKodu = r.DovizKodu ?? "",
                    Devreden = r.Devreden,
                    GunlukGiris = r.GunlukGiris,
                    GunlukCikis = r.GunlukCikis,
                    Bakiye = Math.Abs(r.Bakiye),
                    HasKarsiligi = Math.Abs(r.HasKarsiligi)
                });
            }

            rapor.ToplamBakiyeHas = toplamHasOrijinal;
            return rapor;
        }
    }
}
