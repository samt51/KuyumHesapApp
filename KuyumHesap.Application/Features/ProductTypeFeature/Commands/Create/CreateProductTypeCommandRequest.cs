using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ProductTypeFeature.Commands.Create
{
    public class CreateProductTypeCommandRequest : IRequest<ResponseDto<CreateProductTypeCommandResponse>>
    {
        public string ProductTypeName { get; set; } = null!;
    }
}
