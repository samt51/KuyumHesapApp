using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.MenuFeature.Command.Create;
using KuyumHesap.Application.Features.MenuFeature.Command.Delete;
using KuyumHesap.Application.Features.MenuFeature.Command.Update;
using KuyumHesap.Application.Features.MenuFeature.Queries.GetAll;
using KuyumHesap.Application.Features.MenuFeature.Queries.GetAuthorized;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.MenuCont
{
    public class MenuController : BaseController
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDto<List<GetAllMenuQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllMenuQueryRequest(), token);
        }

        [HttpGet("{userId}")]
        public async Task<ResponseDto<List<GetAuthorizedMenuQueryResponse>>> GetAuthorizedAsync(int userId, CancellationToken token)
        {
            return await _mediator.Send(new GetAuthorizedMenuQueryRequest(userId), token);
        }

        [HttpPost]
        public async Task<ResponseDto<CreateMenuCommandResponse>> CreateAsync(CreateMenuCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpPut]
        public async Task<ResponseDto<UpdateMenuCommandResponse>> UpdateAsync(UpdateMenuCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteMenuCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeleteMenuCommandRequest(id), token);
        }
    }
}
