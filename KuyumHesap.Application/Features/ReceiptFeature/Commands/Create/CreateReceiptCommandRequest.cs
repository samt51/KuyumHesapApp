using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Create
{
    public class CreateReceiptCommandRequest : IRequest<ResponseDto<CreateReceiptCommandResponse>>
    {
        public int Id { get; set; }
        /// <summary>
        /// Fiş Numarası Otomatik Atama
        /// </summary>
        public string ReceiptNumber { get; set; } = string.Empty;
        /// <summary>
        /// Fiş Tarihi
        /// </summary>
        public DateTime ReceiptDate { get; set; }
        /// <summary>
        /// Cari Hesap Id
        /// </summary>
        public int CurrentAccountId { get; set; }
        public required Account Account { get; set; }
        /// <summary>
        /// Personel Id Bilgisi
        /// </summary>
        public int? EmployeeId { get; set; }
        /// <summary>
        /// Açıklama
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Cari Mi ? 
        /// </summary>
        public bool IsCustomerReceipt { get; set; }
        /// <summary>
        /// Para Birimi Kodu
        /// </summary>
        public string? CurrencyCode { get; set; }
        /// <summary>
        /// Açık Hesap Tutarı
        /// </summary>
        public decimal? OpenBalanceAmount { get; set; }
        public List<Movements> Movements { get; set; }
    }
}
