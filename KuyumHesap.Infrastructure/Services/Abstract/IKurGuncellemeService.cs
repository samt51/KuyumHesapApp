using static KuyumHesap.Infrastructure.Services.Dtos.DailyCureDataDto;

namespace KuyumHesap.Infrastructure.Services.Abstract
{
    public interface IKurGuncellemeService
    {
        public Task<string> HariciAPIdenKurlariGuncelle();
      
    }
}
