using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockGroupFeature.Commands.Update
{
    public class UpdateStockGroupCommandRequest : IRequest<ResponseDto<UpdateStockGroupCommandResponse>>
    {
        public int Id { get; set; }
        public string StockGroupName { get; set; } = null!;
    }
}
