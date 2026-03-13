using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;

namespace KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery
{
    public interface IAccountStatementQuery
    {
        Task<List<AccountStatementViewResponseModel>> GetAsync(CancellationToken ct);

        Task<List<AccountStatementViewResponseModel>> GetViewByAccountIdaAndStartBetweenEndDate(int accountId, DateTime start, DateTime end, CancellationToken ct);
    }
}
