using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Command.Delete
{
    public class DeleteAccountTypeCommandRequest : IRequest<ResponseDto<DeleteAccountTypeCommandResponse>>
    {
        public int Id { get; set; }
        public DeleteAccountTypeCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
