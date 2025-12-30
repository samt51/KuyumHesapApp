using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.TaskItemFeature.Commands.Delete
{
    public class DeleteTaskItemCommandRequest : IRequest<ResponseDto<DeleteTaskItemCommandResponse>>
    {
        public int Id { get; set; }
        public DeleteTaskItemCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
