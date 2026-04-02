using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;

namespace KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery
{
    public interface IAccountStatementQuery
    {
        Task<List<AccountStatementViewResponseModel>> GetAsync(CancellationToken ct);

        Task<List<AccountStatementViewResponseModel>> GetViewByAccountIdaAndStartBetweenEndDate(int accountId, DateTime start, DateTime end, int isCustomerReceipt, CancellationToken ct);
        Task<List<GetBalanceAndCurrencyCodeFromView>> GetBalanceAndCurrencyCodeByAccountId(int accountId, DateTime start, CancellationToken ct);
        Task<List<GetBalanceAndCurrencyCodeFromView>> GetViewByAccountIds(int[] accountId, DateTime start, DateTime end, CancellationToken ct);
        Task<List<AccountStatementViewResponseModel>> GetViewByAccountIdsBetweenDate(int[] accountId, DateTime start, DateTime end, CancellationToken ct);
    }
}
