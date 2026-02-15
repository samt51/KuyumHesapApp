using KuyumHesap.Application.Common.Models;

namespace KuyumHesap.Application.Common.Abstractions.Aut
{
    public interface IKurGuncellemeService
    {
        public Task<DailyCureDataDto.Data> GetDailyCureData();
    }
}
