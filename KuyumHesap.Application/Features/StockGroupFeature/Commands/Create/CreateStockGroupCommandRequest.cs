using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockGroupFeature.Commands.Create
{
    public class CreateStockGroupCommandRequest : IRequest<ResponseDto<CreateStockGroupCommandResponse>>
    {
        public string StockGroupName { get; set; } = null!;
    }
}
