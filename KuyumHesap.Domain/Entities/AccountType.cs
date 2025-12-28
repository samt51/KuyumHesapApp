using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    /// <summary>
    /// HESAP TİPLERİ TABLOSU
    /// </summary>
    public class AccountType : BaseEntity
    {

        /// <summary>
        /// Hesap tipi adı
        /// </summary>
        public string AccountTypeName { get; set; } = null!;

        /// <summary>
        /// Bilançoda gösterim sırası
        /// </summary>
        public int BalanceOrder { get; set; }

        /// <summary>
        /// Bilançoda alt hesaplama yapılıp yapılmayacağı
        /// </summary>
        public bool IsSubBalanceCalculated { get; set; }

        /// <summary>
        /// Hesap tipinin aktiflik durumu
        /// </summary>
        public bool IsActive { get; set; }

        public List<Account> Accounts { get; set; }

        public AccountType(List<Account> accounts)
        {
            Accounts = accounts;
        }
    }
}
