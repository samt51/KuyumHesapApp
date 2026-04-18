using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.PageActionFeature.Command.Create;
using KuyumHesap.Application.Features.PageActionFeature.Command.Delete;
using KuyumHesap.Application.Features.PageActionFeature.Command.Update;
using KuyumHesap.Application.Features.PageActionFeature.Queries.CheckAuthorized;
using KuyumHesap.Application.Features.PageActionFeature.Queries.GetAll;
using KuyumHesap.Application.Features.PageActionFeature.Queries.GetAuthorized;
using KuyumHesap.Application.Features.PageActionFeature.Queries.GetByPageCode;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.PageActionCont
{
    public class PageActionController : BaseController
    {
        private readonly IMediator _mediator;

        public PageActionController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDto<List<GetAllPageActionQueryResponse>>> GetAllAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllPageActionQueryRequest(), token);
        }

        [HttpGet("{pageCode}")]
        public async Task<ResponseDto<List<GetPageActionsByPageCodeQueryResponse>>> GetByPageCodeAsync(string pageCode, CancellationToken token)
        {
            return await _mediator.Send(new GetPageActionsByPageCodeQueryRequest(pageCode), token);
        }

       
        public async Task<ResponseDto<List<GetAuthorizedPageActionsQueryResponse>>> AuthorizedAsync([FromQuery] int userId, [FromQuery] string pageCode, CancellationToken token)
        {
            return await _mediator.Send(new GetAuthorizedPageActionsQueryRequest(userId, pageCode), token);
        }

        [HttpGet]
        public async Task<ResponseDto<CheckAuthorizedPageActionQueryResponse>> CheckAuthorizedAsync([FromQuery] int userId, [FromQuery] string pageCode, [FromQuery] string actionCode, CancellationToken token)
        {
            return await _mediator.Send(new CheckAuthorizedPageActionQueryRequest(userId, pageCode, actionCode), token);
        }

        [HttpPost]
        public async Task<ResponseDto<CreatePageActionCommandResponse>> CreateAsync(CreatePageActionCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpPut]
        public async Task<ResponseDto<UpdatePageActionCommandResponse>> UpdateAsync(UpdatePageActionCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeletePageActionCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeletePageActionCommandRequest(id), token);
        }
    }
}
