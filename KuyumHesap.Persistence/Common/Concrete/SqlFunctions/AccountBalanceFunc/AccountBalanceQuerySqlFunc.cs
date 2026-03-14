using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;
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
        public async Task<CashReportModelResponseDto> GetReportByAccountTypeNameAsync(string accountTypeName, int? accountId, CancellationToken ct)
        {
            var today = DateTime.Today;

            var sql = @"
SELECT 
    ISNULL(h.BalanceUnit, '') AS CurrencyCode,
    ISNULL(SUM(
        CASE 
            WHEN CAST(h.ReceiptDate AS DATE) < {0} 
                THEN CASE WHEN h.IsEntry = 1 THEN h.BalanceEffectAmount ELSE -h.BalanceEffectAmount END
            ELSE 0
        END
    ), 0) AS OpeningBalance,
    ISNULL(SUM(
        CASE 
            WHEN CAST(h.ReceiptDate AS DATE) = {0} AND h.IsEntry = 1 
                THEN h.BalanceEffectAmount 
            ELSE 0
        END
    ), 0) AS DailyCredit,
    ISNULL(SUM(
        CASE 
            WHEN CAST(h.ReceiptDate AS DATE) = {0} AND h.IsEntry = 0 
                THEN h.BalanceEffectAmount 
            ELSE 0
        END
    ), 0) AS DailyDebit,
    ISNULL(SUM(
        CASE 
            WHEN CAST(h.ReceiptDate AS DATE) <= {0} 
                THEN CASE WHEN h.IsEntry = 1 THEN h.BalanceEffectAmount ELSE -h.BalanceEffectAmount END
            ELSE 0
        END
    ), 0) AS Balance,
    dbo.fn_KurCevir(
        {0},
        h.BalanceUnit,
        'HAS',
        ISNULL(SUM(
            CASE 
                WHEN CAST(h.ReceiptDate AS DATE) <= {0} 
                    THEN CASE WHEN h.IsEntry = 1 THEN h.BalanceEffectAmount ELSE -h.BalanceEffectAmount END
                ELSE 0
            END
        ), 0)
    ) AS HasEquivalent
FROM vw_HesapEkstresi h
WHERE ({1} IS NULL OR h.AccountTypeName = {1})
  AND ({2} IS NULL OR h.AccountId = {2})
GROUP BY h.BalanceUnit
ORDER BY h.BalanceUnit;";

            var rows = await _context.Database
                .SqlQueryRaw<CashRegisterStatusResponse>(sql, today, accountTypeName, accountId)
                .ToListAsync(ct);

            var rapor = new CashReportModelResponseDto();

            decimal toplamHasOrijinal = 0m;

            foreach (var r in rows)
            {
                toplamHasOrijinal += r.HasEquivalent;

                rapor.Details.Add(new CashRegisterStatusResponse
                {
                    CurrencyCode = r.CurrencyCode ?? "",
                    OpeningBalance = r.OpeningBalance,
                    DailyCredit = r.DailyCredit,
                    DailyDebit = r.DailyDebit,
                    Balance = Math.Abs(r.Balance),
                    HasEquivalent = Math.Abs(r.HasEquivalent)
                });
            }

            rapor.TotalBalanceHas = toplamHasOrijinal;
            return rapor;
        }
    }
}
