namespace KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery
{
    public interface ITotalHasBalanceQuery
    {
        Task<decimal> GetTotalHasAsync(string hesapTipiAdi, CancellationToken ct);

    }
}
