using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Command.Delete
{
    public class DeletePageActionCommandRequest : IRequest<ResponseDto<DeletePageActionCommandResponse>>
    {
        public int Id { get; set; }

        public DeletePageActionCommandRequest(int id)
        {
            Id = id;
        }
    }
}
