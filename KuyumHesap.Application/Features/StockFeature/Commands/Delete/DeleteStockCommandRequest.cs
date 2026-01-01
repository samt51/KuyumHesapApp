using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockFeature.Commands.Delete
{
    public class DeleteStockCommandRequest : IRequest<ResponseDto<DeleteStockCommandResponse>>
    {
        public int Id { get; set; }
        public DeleteStockCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
