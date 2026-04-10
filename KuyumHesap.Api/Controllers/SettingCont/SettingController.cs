using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.SettingFeature.Command.Create;
using KuyumHesap.Application.Features.SettingFeature.Command.Update;
using KuyumHesap.Application.Features.SettingFeature.Queries.GetAll;
using KuyumHesap.Application.Features.SettingFeature.Queries.CheckTable;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using KuyumHesap.Application.Features.SettingFeature.Command.DeleteAllSystem;

namespace KuyumHesap.Api.Controllers.SettingCont
{
    public class SettingController : BaseController
    {
        private readonly IMediator _mediator;
        public SettingController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseDto<List<GetAllSettingQueryResponse>>> GetAll(CancellationToken token)
        {
            return await _mediator.Send(new GetAllSettingQueryRequest(), token);
        }

        [HttpPost]
        public async Task<ResponseDto<CreateSettingCommandResponse>> Create(CreateSettingCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpPost]
        public async Task<ResponseDto<UpdateSettingCommandResponse>> Update(UpdateSettingCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }

        [HttpGet]
        public async Task<ResponseDto<CheckSettingTableQueryResponse>> CheckTable(CancellationToken token)
        {
            return await _mediator.Send(new CheckSettingTableQueryRequest(), token);
        }
        [HttpGet]
        public async Task<ResponseDto<DeleteAllSystemCommandResponse>> DeleteAllSystem(CancellationToken token)
        {
            return await _mediator.Send(new DeleteAllSystemCommandRequest(), token);
        }
    }
}