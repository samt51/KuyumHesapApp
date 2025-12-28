using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Command.Delete
{
    public class DeleteAccountCommandRequest: IRequest<ResponseDto<DeleteAccountCommandResponse>>
    {
        public int Id { get; set; }
    }
}
