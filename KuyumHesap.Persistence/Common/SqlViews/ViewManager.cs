using KuyumHesap.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Persistence.Common.SqlViews
{
    public static class ViewManager
    {
        public static async Task EnsureViewsAsync(AppDbContext db, CancellationToken ct = default)
        {
            // vw_HesapEkstresi view'ini CREATE OR ALTER kullanarak garanti altýna alýyoruz.
            // Gelen orijinal sorgudan sütun isimlerini proje modeline uygun Türkçe isimlerle alias'ladým.
            var sql = @"CREATE OR ALTER VIEW dbo.vw_HesapEkstresi AS
SELECT  
    h.Id as MovementId,
    f.Id as ReceiptId,
    f.ReceiptDate as ReceiptDate,
    h.AccountId as AccountId,
    hs.AccountName as AccountName,
    ht.TransactionName AS TransactionName,
    ISNULL(CASE 
        WHEN h.StockId IS NOT
        NULL THEN h.Quantity 
        ELSE h.ForeignCurrencyAmount 
    END, 0) AS Quantity,
    ISNULL(d.CurrencyCode, '') AS Unit,
    ISNULL(h.ForeignExchangeRate, 0) AS Rate,
    ISNULL(NULLIF(h.CounterCurrencyAmount, 0), h.ForeignCurrencyAmount) AS CounterQuantity,
    ISNULL(kd.CurrencyCode, d.CurrencyCode) AS CounterUnit,
    ISNULL(h.CounterExchangeRate, 0) AS CounterRate,
    h.StockId,
    s.StockName,
    h.MillRate,
    h.LaborCost,
    h.LaborUnit,
    h.LaborQuantity,
    h.IsLaborIncluded,
    h.NetProductValue,
    h.TotalLaborCost,

    CASE 
        WHEN h.StockId IS NOT NULL 
            THEN ISNULL(h.NetProductValue, 0) + ISNULL(h.TotalLaborCost, 0)
        ELSE ISNULL(NULLIF(h.CounterCurrencyAmount, 0), h.ForeignCurrencyAmount)
    END AS BalanceEffectAmount,

    CASE 
        WHEN h.StockId IS NOT NULL THEN 'HAS'
        ELSE ISNULL(kd.CurrencyCode, d.CurrencyCode)
    END AS BalanceUnit,

    h.Description,
    h.IsReconciled,

    CASE 
        WHEN h.TransactionTypeId IN (1, 3, 5, 7, 9) THEN 1 
        ELSE 0 
    END AS IsEntry,

    s.UnitName AS StockUnit,
    hstip.Id as AccountTypeId,
    hstip.AccountTypeName as AccountTypeName,
    acc.Id as ReceiptAccounId,
    acc.AccountName as ReceiptAccountName,
    tip.AccountTypeName as ReceiptAccounTypeName,
    ht.Id as TransactionTypeId,
    f.IsCustomerReceipt,
    h.CounterCurrencyId AS ForeignCurrencyId,
    counterAccount.AccountName as CounterAccountName,
    h.CreatedDate as MovementCreatedDate


FROM dbo.Movements AS h

INNER JOIN dbo.Receipts AS f ON h.ReceiptId = f.Id
INNER JOIN dbo.MovementTypes AS ht ON h.TransactionTypeId = ht.Id
LEFT JOIN dbo.Currencies AS d ON h.ForeignCurrencyId = d.ID
LEFT JOIN dbo.Currencies AS kd ON h.CounterCurrencyId = kd.ID
LEFT JOIN dbo.Stocks AS s ON h.StockId = s.Id
LEFT JOIN dbo.Accounts AS hs ON hs.Id = h.AccountId
LEFT JOIN dbo.Accounts AS acc ON acc.Id = f.AccountId
LEFT JOIN dbo.AccountTypes AS tip ON tip.Id = acc.AccountTypeId
LEFT JOIN dbo.AccountTypes AS hstip ON hstip.Id = hs.AccountTypeId
LEFT JOIN dbo.Movements AS counterMovement ON counterMovement.Id = h.CounterTransactionId
LEFT JOIN dbo.Accounts AS counterAccount ON counterAccount.Id = counterMovement.AccountId

WHERE 
    h.IsDeleted = 0 
    AND f.IsDeleted = 0
";
            await db.Database.ExecuteSqlRawAsync(sql, ct);
        }
    }
}