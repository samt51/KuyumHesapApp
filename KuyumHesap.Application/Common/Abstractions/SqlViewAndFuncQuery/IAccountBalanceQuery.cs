using KuyumHesap.Application.Common.Models.Dtos;

namespace KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery
{
    public interface IAccountBalanceQuery
    {
        Task<KasaRaporuViewModelDto> GetAsync(string hesapTipiAdi, int? hesapId, CancellationToken ct);

    }
}
