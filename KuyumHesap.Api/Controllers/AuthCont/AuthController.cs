using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Api.Common.Filters;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.AuthFeature.Commands.Login;
using KuyumHesap.Application.Features.AuthFeature.Commands.Register;
using KuyumHesap.Application.Features.UserFeature.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.AuthCont
{
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [AllowAnonymous]
        [SwaggerDescriptionAttirbute("Login")]
        public async Task<ResponseDto<LoginCommandResponse>> LoginAsync(LoginCommandRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost]
        [SwaggerDescriptionAttirbute("Register")]
        public async Task<ResponseDto<RegisterCommandResponse>> RegisterAsync(RegisterCommandRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPut]
        [SwaggerDescriptionAttirbute("Update")]
        public async Task<ResponseDto<UpdateUserCommandResponse>> UpdateAsync(UpdateUserCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
    }
}
