using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockGroupFeature.Commands.Delete
{
    public class DeleteStockGroupCommandRequest : IRequest<ResponseDto<DeleteStockGroupCommandResponse>>
    {
        public int Id { get; set; }
        public DeleteStockGroupCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
