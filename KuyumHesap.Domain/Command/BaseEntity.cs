namespace KuyumHesap.Domain.Command
{
    public abstract class BaseEntity : IBaseEntity
    {
        /// <summary>
        /// Entitylerdeki Ortak Id alanı
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// EKLEME TARİHİ
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// GÜNCELLEME TARİHİ
        /// </summary>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// Soft Delete için kullanılan alan
        /// </summary>
        public bool IsDeleted { get; set; } = false;
        /// <summary>
        /// Ekleyen Kullanıcı Id
        /// </summary>
        public int CreatedByUserId { get; set; }
        /// <summary>
        /// Güncelleyen Kullanıcı Id
        /// </summary>
        public int? UpdatedByUserId { get; set; }
    }
}
