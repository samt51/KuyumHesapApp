using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockTypeFeature.Commands.Delete
{
    public class DeleteStockTypeCommandRequest : IRequest<ResponseDto<DeleteStockTypeCommandResponse>>
    {
        public int Id { get; set; }
        public DeleteStockTypeCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
