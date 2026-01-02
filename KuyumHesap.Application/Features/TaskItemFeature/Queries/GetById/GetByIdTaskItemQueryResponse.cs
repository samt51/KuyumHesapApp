using KuyumHesap.Application.Common.Models.Dtos.ResponseDtos;
using KuyumHesap.Domain.Enums;

namespace KuyumHesap.Application.Features.TaskItemFeature.Queries.GetById
{
    public class GetByIdTaskItemQueryResponse
    {
        public int Id { get; set; }
        /// <summary>
        /// Görev başlığı
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Görev açıklaması
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Görevi atayan kullanıcı kimliği
        /// </summary>
        public UserResponseDto AssignedByUser { get; set; }

        /// <summary>
        /// Görevin atandığı kullanıcı kimliği
        /// </summary>
        public UserResponseDto? AssignedToUser { get; set; }

        /// <summary>
        /// Görevin oluşturulma tarihi
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Görevin bitiş (son teslim) tarihi
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Görevin durumu (Bekliyor, Devam Ediyor, Tamamlandı)
        /// </summary>
        public TaskStateEnum Status { get; set; }

        /// <summary>
        /// Görevin öncelik seviyesi (Düşük, Normal, Yüksek, Acil)
        /// </summary>
        public PriorityEnum Priority { get; set; }

        /// <summary>
        /// Görevin aktiflik durumu
        /// </summary>
        public bool IsActive { get; set; }
    }
}
