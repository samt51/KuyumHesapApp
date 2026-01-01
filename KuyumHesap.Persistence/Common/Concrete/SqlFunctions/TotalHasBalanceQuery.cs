using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Persistence.Common.Concrete.SqlFunctions
{
    public sealed class TotalHasBalanceQuery : ITotalHasBalanceQuery
    {
        private readonly AppDbContext _context;

        public TotalHasBalanceQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalHasAsync(string hesapTipiAdi, CancellationToken ct)
        {
            var bugun = DateTime.Today;

            // Tek sorgu: Döviz bazlı bakiyeyi hesapla, fn_KurCevir ile HAS'a çevir, hepsini topla
            var sql = @"
SELECT 
    ABS(ISNULL(SUM(
        dbo.fn_KurCevir(
            {0},                -- Bugun
            t.BakiyeBirimi,     -- Kaynak doviz
            'HAS',              -- Hedef
            t.Bakiye            -- Miktar
        )
    ), 0))
FROM (
    SELECT 
        h.BakiyeBirimi,
        SUM(CASE WHEN h.GirisMi = 1 THEN h.BakiyeEtkiMiktari ELSE -h.BakiyeEtkiMiktari END) AS Bakiye
    FROM vw_HesapEkstresi h
    WHERE h.HesapTipiAdi = {1}
      AND CAST(h.Tarih AS DATE) <= {0}
    GROUP BY h.BakiyeBirimi
) t;";

            var toplamHas = await _context.Database
                .SqlQueryRaw<decimal>(sql, bugun.Date, hesapTipiAdi)
                .SingleOrDefaultAsync(ct);

            return toplamHas;
        }
    }

}
