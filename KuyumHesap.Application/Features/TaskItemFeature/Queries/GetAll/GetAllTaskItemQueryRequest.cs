using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Enums;
using MediatR;

namespace KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAll
{
    public class GetAllTaskItemQueryRequest : IRequest<ResponseDto<List<GetAllTaskItemQueryResponse>>>
    {
        public int UserId { get; set; }
        public TaskStateEnum Status { get; set; } 
    }
}
