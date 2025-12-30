using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Commands.Delete
{
    public class DeleteExchangeCommandRequest : IRequest<ResponseDto<DeleteExchangeCommandResponse>>
    {
        public int Id { get; set; }
        public DeleteExchangeCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
