namespace KuyumHesap.Application.Common.Models.Dtos.SqlResponse
{
    public class GetBalanceAndCurrencyCodeFromView
    {
        public string DovizKodu { get; set; }
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
        public int ForeignCurrencyId { get; set; }
    }
}
