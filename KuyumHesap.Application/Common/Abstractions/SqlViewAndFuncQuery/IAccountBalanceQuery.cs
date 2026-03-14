using KuyumHesap.Application.Common.Models.Dtos;

namespace KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery
{
    public interface IAccountBalanceQuery
    {
        Task<CashReportModelResponseDto> GetReportByAccountTypeNameAsync(string accountTypeName, int? accountId, CancellationToken ct);

    }
}
