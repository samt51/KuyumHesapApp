using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ProductTypeFeature.Commands.Delete
{
    public class DeleteProductTypeCommandRequest : IRequest<ResponseDto<DeleteProductTypeCommandResponse>>
    {
        public int Id { get; set; }
        public DeleteProductTypeCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
