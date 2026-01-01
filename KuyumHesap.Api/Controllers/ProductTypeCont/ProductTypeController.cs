using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.ProductTypeFeature.Commands.Create;
using KuyumHesap.Application.Features.ProductTypeFeature.Commands.Delete;
using KuyumHesap.Application.Features.ProductTypeFeature.Commands.Update;
using KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.ProductTypeCont
{
    public class ProductTypeController : BaseController
    {
        private readonly IMediator _mediator;
        public ProductTypeController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public Task<ResponseDto<GetByIdProductTypeQueryResponse>> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetByIdProductTypeQueryRequest(id), cancellationToken);
        }
        [HttpGet]
        public Task<ResponseDto<List<GetAllProductTypeQueryResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetAllProductTypeQueryRequest(), cancellationToken);
        }
        [HttpDelete("{id}")]
        public Task<ResponseDto<DeleteProductTypeCommandResponse>> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            return _mediator.Send(new DeleteProductTypeCommandRequest(id), cancellationToken);
        }
        [HttpPost]
        public Task<ResponseDto<UpdateProductTypeCommandResponse>> CreateAsync(UpdateProductTypeCommandRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
        [HttpPost]
        public Task<ResponseDto<CreateProductTypeCommandResponse>> CreateAsync(CreateProductTypeCommandRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
    }
}
