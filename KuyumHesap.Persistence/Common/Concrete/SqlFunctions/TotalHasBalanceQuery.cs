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

            var sql = @"
SELECT 
    CAST(ABS(ISNULL(SUM(
        dbo.fn_KurCevir(
            @p0,
            t.BakiyeBirimi,
            'HAS',
            t.Bakiye
        )
    ), 0)) AS decimal(18,2)) AS [Value]
FROM (
    SELECT 
        h.BakiyeBirimi,
        SUM(CASE WHEN h.GirisMi = 1 
                 THEN h.BakiyeEtkiMiktari 
                 ELSE -h.BakiyeEtkiMiktari 
            END) AS Bakiye
    FROM vw_HesapEkstresi h
    WHERE h.HesapTipiAdi = @p1
      AND CAST(h.Tarih AS DATE) <= @p0
    GROUP BY h.BakiyeBirimi
) t";

            var toplamHas = await _context.Database
                .SqlQueryRaw<decimal>(sql, bugun, hesapTipiAdi)
                .SingleAsync(ct);

            return toplamHas;
        }
    }

}
