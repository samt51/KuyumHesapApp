KuyumHesap.Application\Common\Abstractions\SqlViewAndFuncQuery\IAccountStatementQuery.cs
using KuyumHesap.Application.Common.Models.Dtos.SqlResponse;

namespace KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery
{
    public interface IAccountStatementQuery
    {
        Task<List<AccountStatementViewResponseModel>> GetAsync(string hesapTipiAdi, int? hesapId, CancellationToken ct);
    }
}