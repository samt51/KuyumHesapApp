using KuyumHesap.Application.Common.Models.Dtos;

namespace KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAllMyTask
{
    public class GetAllMyTaskQueryResponse
    {
        /// <summary>
        /// Geçmiş Görevler 
        /// </summary>
        public List<GetAllMyTaskQueryResponseDto> PastMissions { get; set; }
        /// <summary>
        /// Bugünkü Görevler 
        /// </summary>
        public List<GetAllMyTaskQueryResponseDto> CurrentMissions { get; set; }
        /// <summary>
        /// Gelecek Görevler 
        /// </summary>
        public List<GetAllMyTaskQueryResponseDto> FutureMissions { get; set; }
    }
}
