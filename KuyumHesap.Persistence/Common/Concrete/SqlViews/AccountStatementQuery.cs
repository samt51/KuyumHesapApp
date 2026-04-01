using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;
using KuyumHesap.Persistence.Common.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace KuyumHesap.Persistence.Common.Concrete.SqlViews
{
    public class AccountStatementQuery : IAccountStatementQuery
    {
        private readonly AppDbContext _context;

        public AccountStatementQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccountStatementViewResponseModel>> GetAsync(CancellationToken ct)
        {
            var sql = @"
SELECT
    MovementId,
    ReceiptId,
    ReceiptDate,
    AccountId,
    TransactionName,
    ISNULL(Quantity, 0)          AS Quantity,
    ISNULL(Unit, '')             AS Unit,
    ISNULL(Rate, 0)              AS Rate,
    ISNULL(CounterQuantity, 0)   AS CounterQuantity,
    ISNULL(CounterUnit, '')      AS CounterUnit,
    ISNULL(CounterRate, 0)       AS CounterRate,
    StockId,
    StockName,
    MillRate,
    LaborCost,
    LaborUnit,
    LaborQuantity,
    CAST(ISNULL(IsLaborIncluded, 0) AS bit) AS IsLaborIncluded,
    NetProductValue,
    TotalLaborCost,
    ISNULL(BalanceEffectAmount, 0) AS BalanceEffectAmount,
    ISNULL(BalanceUnit, '')       AS BalanceUnit,
    Description,
    CAST(ISNULL(IsReconciled, 0) AS bit)    AS IsReconciled,
    CAST(ISNULL(IsEntry, 0) AS bit)         AS IsEntry,
    ISNULL(StockUnit, '')         AS StockUnit,
    AccountTypeId,
    AccountTypeName,
ReceiptAccounId,
ReceiptAccountName,
ReceiptAccounTypeName,
TransactionTypeId
FROM dbo.vw_HesapEkstresi
ORDER BY ReceiptDate, MovementId;

";

            var rows = await _context.Database
                .SqlQueryRaw<AccountStatementViewResponseModel>(sql)
                .ToListAsync(ct);

            return rows;
        }

        public async Task<List<GetBalanceAndCurrencyCodeFromView>> GetBalanceAndCurrencyCodeByAccountId(int accountId, DateTime start, CancellationToken ct)
        {
            var sql = @"
						 SELECT 
    BalanceUnit AS DovizKodu,
    SUM(CASE WHEN IsEntry = 1 THEN BalanceEffectAmount ELSE -BalanceEffectAmount END) AS Balance
FROM vw_HesapEkstresi
WHERE AccountId = {0} AND ReceiptDate < {1}
GROUP BY BalanceUnit;";

            var rows = await _context.Database.SqlQueryRaw<GetBalanceAndCurrencyCodeFromView>(sql, accountId, start).ToListAsync(ct);

            return rows;
        }

        public async Task<List<AccountStatementViewResponseModel>> GetViewByAccountIdaAndStartBetweenEndDate(int accountId, DateTime start, DateTime end, CancellationToken ct)
        {
            var sql = @"SELECT
    MovementId,
    ReceiptId,
    ReceiptDate,
    AccountId,
    TransactionName,
    ISNULL(Quantity, 0)          AS Quantity,
    ISNULL(Unit, '')             AS Unit,
    ISNULL(Rate, 0)              AS Rate,
    ISNULL(CounterQuantity, 0)   AS CounterQuantity,
    ISNULL(CounterUnit, '')      AS CounterUnit,
    ISNULL(CounterRate, 0)       AS CounterRate,
    StockId,
    StockName,
    MillRate,
    LaborCost,
    LaborUnit,
    LaborQuantity,
    CAST(ISNULL(IsLaborIncluded, 0) AS bit) AS IsLaborIncluded,
    NetProductValue,
    TotalLaborCost,
    ISNULL(BalanceEffectAmount, 0) AS BalanceEffectAmount,
    ISNULL(BalanceUnit, '')       AS BalanceUnit,
    Description,
    CAST(ISNULL(IsReconciled, 0) AS bit)    AS IsReconciled,
    CAST(ISNULL(IsEntry, 0) AS bit)         AS IsEntry,
    ISNULL(StockUnit, '')         AS StockUnit,
    AccountTypeId,
    AccountTypeName,
ReceiptAccounId,
ReceiptAccountName,
ReceiptAccounTypeName,
TransactionTypeId
FROM dbo.vw_HesapEkstresi
WHERE AccountId = {0} AND ReceiptDate BETWEEN {1} AND {2}
ORDER BY ReceiptDate, MovementId;";

            var rows = await _context.Database.SqlQueryRaw<AccountStatementViewResponseModel>(sql, accountId, start, end).ToListAsync(ct);

            return rows;
        }
        public async Task<List<GetBalanceAndCurrencyCodeFromView>> GetViewByAccountIds(int[] accountId, DateTime start, DateTime end, CancellationToken ct)
        {
            // Eğer accountId boş ise boş liste döndür
            if (accountId == null || accountId.Length == 0)
                return new List<GetBalanceAndCurrencyCodeFromView>();

            // accountId int[] sunucu tarafından geldiği varsayılarak güvenli şekilde virgülle birleştiriyoruz.
            // Eğer bu input dış kaynaklı ise SQL injection riski açısından TVP veya parametrized approach kullanın.
            var ids = string.Join(",", accountId.Select(i => i.ToString()));

            var sql = $@"
						 SELECT 
    BalanceUnit AS DovizKodu,
    SUM(CASE WHEN IsEntry = 1 THEN BalanceEffectAmount ELSE -BalanceEffectAmount END) AS Balance
FROM vw_HesapEkstresi
WHERE AccountId IN ({ids}) AND ReceiptDate < @start
GROUP BY BalanceUnit;";

            var param = new SqlParameter("@start", SqlDbType.DateTime) { Value = start };

            var rows = await _context.Database.SqlQueryRaw<GetBalanceAndCurrencyCodeFromView>(sql, param).ToListAsync(ct);

            return rows;
        }
        public async Task<List<AccountStatementViewResponseModel>> GetViewByAccountIdsBetweenDate(
       int[] accountId,
       DateTime start,
       DateTime end,
       CancellationToken ct)
        {
            if (accountId == null || accountId.Length == 0)
                return new List<AccountStatementViewResponseModel>();

            // AccountId placeholderları: {0}, {1}, {2} ...
            // accountId int[] sunucu tarafından geldiği varsayılarak güvenli şekilde virgülle birleştiriyoruz.
            // Eğer bu input dış kaynaklı ise SQL injection riski açısından TVP veya parametrized approach kullanın.
            var ids = string.Join(",", accountId.Select(i => i.ToString()));


            var sql = $@"
SELECT
    MovementId,
    ReceiptId,
    ReceiptDate,
    AccountId,
    TransactionName,
    ISNULL(Quantity, 0) AS Quantity,
    ISNULL(Unit, '') AS Unit,
    ISNULL(Rate, 0) AS Rate,
    ISNULL(CounterQuantity, 0) AS CounterQuantity,
    ISNULL(CounterUnit, '') AS CounterUnit,
    ISNULL(CounterRate, 0) AS CounterRate,
    StockId,
    StockName,
    MillRate,
    LaborCost,
    LaborUnit,
    LaborQuantity,
    CAST(ISNULL(IsLaborIncluded, 0) AS bit) AS IsLaborIncluded,
    NetProductValue,
    TotalLaborCost,
    ISNULL(BalanceEffectAmount, 0) AS BalanceEffectAmount,
    ISNULL(BalanceUnit, '') AS BalanceUnit,
    Description,
    CAST(ISNULL(IsReconciled, 0) AS bit) AS IsReconciled,
    CAST(ISNULL(IsEntry, 0) AS bit) AS IsEntry,
    ISNULL(StockUnit, '') AS StockUnit,
    AccountTypeId,
    AccountTypeName,
    ReceiptAccounId,
    ReceiptAccountName,
    ReceiptAccounTypeName,
    TransactionTypeId
FROM dbo.vw_HesapEkstresi
WHERE AccountId IN (" + ids + @")
  AND ReceiptDate BETWEEN @start AND @end
ORDER BY ReceiptDate, MovementId;";

            var paramStart = new SqlParameter("@start", SqlDbType.DateTime) { Value = start };
            var paramEnd = new SqlParameter("@end", SqlDbType.DateTime) { Value = end };

            var rows = await _context.Database
                .SqlQueryRaw<AccountStatementViewResponseModel>(sql, paramStart, paramEnd)
                .ToListAsync(ct);

            return rows;
        }
    }
}