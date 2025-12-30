namespace KuyumHesap.Infrastructure.Services.Abstract
{
    public interface IKurGuncellemeService
    {
        public Task<string> KurlariHazirlaVeGuncelle();
        public Task<string> HariciAPIdenKurlariGuncelle();
        public Task<string> KurlariGuncelle();
    }
}
