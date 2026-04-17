using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Command.Delete
{
    public class DeleteMenuCommandRequest : IRequest<ResponseDto<DeleteMenuCommandResponse>>
    {
        public int Id { get; set; }

        public DeleteMenuCommandRequest(int id)
        {
            Id = id;
        }
    }
}
