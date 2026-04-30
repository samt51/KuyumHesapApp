using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;
using KuyumHesap.Persistence.Common.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
TransactionTypeId,
 CAST(ISNULL(IsCustomerReceipt, 0) AS bit)    AS IsCustomerReceipt,
AccountName
FROM dbo.vw_HesapEkstresi
ORDER BY ReceiptDate, MovementId;

";

            var rows = await _context.Database
                .SqlQueryRaw<AccountStatementViewResponseModel>(sql)
                .ToListAsync(ct);

            return rows;
        }

        public async Task<List<GetBalanceAndCurrencyCodeFromView>> GetBalanceAndCurrencyCodeByAccountId(
      int accountId,
      DateTime start,
      CancellationToken ct)
        {
            var sql = @"
SELECT 
    BalanceUnit AS DovizKodu,
    SUM(CASE WHEN IsEntry = 1 THEN BalanceEffectAmount ELSE -BalanceEffectAmount END) AS Balance,
    AccountId
FROM vw_HesapEkstresi
WHERE AccountId = @accountId AND ReceiptDate < @start
GROUP BY BalanceUnit, AccountId;";

            var param1 = new SqlParameter("@accountId", SqlDbType.Int) { Value = accountId };
            var param2 = new SqlParameter("@start", SqlDbType.DateTime) { Value = start };

            var rows = await _context.Database
                .SqlQueryRaw<GetBalanceAndCurrencyCodeFromView>(sql, param1, param2)
                .ToListAsync(ct);

            return rows;
        }

        public async Task<List<AccountStatementViewResponseModel>> GetFinancialViewByFilterBetweenDate(
        int[] accountId,
        string[]? currencyCode,
        DateTime start,
        DateTime end,
        CancellationToken ct)
        {
            if (accountId == null || accountId.Length == 0)
                return new List<AccountStatementViewResponseModel>();

            var accountIdParameters = accountId
                .Select((id, index) => new SqlParameter($"@accountId{index}", SqlDbType.Int) { Value = id })
                .ToArray();

            var accountInClause = string.Join(", ", accountIdParameters.Select(p => p.ParameterName));

            var currencyParameters = currencyCode?
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct()
                .Select((code, index) => new SqlParameter($"@unit{index}", SqlDbType.NVarChar) { Value = code })
                .ToArray() ?? Array.Empty<SqlParameter>();

            var currencyFilter = "";

            if (currencyParameters.Any())
            {
                var currencyInClause = string.Join(", ", currencyParameters.Select(p => p.ParameterName));
                currencyFilter = $" AND BalanceUnit IN ({currencyInClause})";
            }

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
    TransactionTypeId,
    CAST(ISNULL(IsCustomerReceipt, 0) AS bit) AS IsCustomerReceipt,
    AccountName
FROM dbo.vw_HesapEkstresi
WHERE AccountId IN ({accountInClause})
  AND ReceiptDate BETWEEN @start AND @end
  {currencyFilter}
ORDER BY ReceiptDate, MovementId;";

            var paramStart = new SqlParameter("@start", SqlDbType.DateTime) { Value = start };
            var paramEnd = new SqlParameter("@end", SqlDbType.DateTime) { Value = end };

            var parameters = accountIdParameters
                .Cast<object>()
                .Concat(currencyParameters.Cast<object>())
                .Append(paramStart)
                .Append(paramEnd)
                .ToArray();

            var rows = await _context.Database
                .SqlQueryRaw<AccountStatementViewResponseModel>(sql, parameters)
                .ToListAsync(ct);

            return rows;
        }

        public async Task<List<AccountStatementViewResponseModel>> GetStockViewByFilterBetweenDate(int[] stockId, DateTime start, DateTime end, CancellationToken ct)
        {
            if (stockId == null || stockId.Length == 0)
                return new List<AccountStatementViewResponseModel>();

            var accountIdParameters = stockId
                .Select((id, index) => new SqlParameter($"@stockId{index}", SqlDbType.Int) { Value = id })
                .ToArray();

            var inClause = string.Join(", ", accountIdParameters.Select(p => p.ParameterName));

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
    TransactionTypeId,
    CAST(ISNULL(IsCustomerReceipt, 0) AS bit) AS IsCustomerReceipt,
    AccountName
FROM dbo.vw_HesapEkstresi
WHERE StockId IN ({inClause})
  AND ReceiptDate BETWEEN @start AND @end
ORDER BY ReceiptDate, MovementId;";

            var paramStart = new SqlParameter("@start", SqlDbType.DateTime) { Value = start };
            var paramEnd = new SqlParameter("@end", SqlDbType.DateTime) { Value = end };

            var parameters = accountIdParameters
                .Cast<object>()
                .Append(paramStart)
                .Append(paramEnd)
                .ToArray();

            var rows = await _context.Database
                .SqlQueryRaw<AccountStatementViewResponseModel>(sql, parameters)
                .ToListAsync(ct);

            return rows;
        }


        public async Task<List<AccountStatementViewResponseModel>> GetViewByAccountIdaAndStartBetweenEndDate(int accountId, DateTime start, DateTime end, int isCustomerReceipt, CancellationToken ct)
        {
            try
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
TransactionTypeId,
 CAST(ISNULL(IsCustomerReceipt, 0) AS bit)    AS IsCustomerReceipt,
 AccountName
FROM dbo.vw_HesapEkstresi
WHERE AccountId = {0} AND ReceiptDate BETWEEN {1} AND {2} AND IsCustomerReceipt ={3}
ORDER BY ReceiptDate, MovementId;";

                var rows = await _context.Database.SqlQueryRaw<AccountStatementViewResponseModel>(sql, accountId, start, end, isCustomerReceipt).ToListAsync(ct);

                return rows;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<GetBalanceAndCurrencyCodeFromView>> GetViewByAccountIds(
       int[] accountIds,
       DateTime start,
       DateTime end,
       CancellationToken ct)
        {
            if (accountIds == null || accountIds.Length == 0)
                return new List<GetBalanceAndCurrencyCodeFromView>();

            var accountIdParameters = accountIds
                .Select((id, index) => new SqlParameter($"@accountId{index}", SqlDbType.Int) { Value = id })
                .ToArray();

            var inClause = string.Join(", ", accountIdParameters.Select(p => p.ParameterName));

            var sql = $@"
        SELECT 
            BalanceUnit AS DovizKodu,
            SUM(CASE WHEN IsEntry = 1 THEN BalanceEffectAmount ELSE -BalanceEffectAmount END) AS Balance,
            AccountId
        FROM vw_HesapEkstresi
        WHERE AccountId IN ({inClause})
          AND ReceiptDate < @start
        GROUP BY BalanceUnit, AccountId;";

            var startParameter = new SqlParameter("@start", SqlDbType.DateTime)
            {
                Value = start
            };

            var parameters = accountIdParameters
                .Cast<object>()
                .Append(startParameter)
                .ToArray();

            var rows = await _context.Database
                .SqlQueryRaw<GetBalanceAndCurrencyCodeFromView>(sql, parameters)
                .ToListAsync(ct);

            return rows;
        }


        public async Task<List<AccountStatementViewResponseModel>> GetViewByAccountIdsBetweenDate(
    int[] accountIds,
    DateTime start,
    DateTime end,
    CancellationToken ct)
        {
            if (accountIds == null || accountIds.Length == 0)
                return new List<AccountStatementViewResponseModel>();

            var accountIdParameters = accountIds
                .Select((id, index) => new SqlParameter($"@accountId{index}", SqlDbType.Int) { Value = id })
                .ToArray();

            var inClause = string.Join(", ", accountIdParameters.Select(p => p.ParameterName));

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
    TransactionTypeId,
    CAST(ISNULL(IsCustomerReceipt, 0) AS bit) AS IsCustomerReceipt,
    AccountName
FROM dbo.vw_HesapEkstresi
WHERE AccountId IN ({inClause})
  AND ReceiptDate BETWEEN @start AND @end
ORDER BY ReceiptDate, MovementId;";

            var paramStart = new SqlParameter("@start", SqlDbType.DateTime) { Value = start };
            var paramEnd = new SqlParameter("@end", SqlDbType.DateTime) { Value = end };

            var parameters = accountIdParameters
                .Cast<object>()
                .Append(paramStart)
                .Append(paramEnd)
                .ToArray();

            var rows = await _context.Database
                .SqlQueryRaw<AccountStatementViewResponseModel>(sql, parameters)
                .ToListAsync(ct);

            return rows;
        }


    }
}