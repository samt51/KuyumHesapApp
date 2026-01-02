using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Api.Common.Filters;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.AuthFeature.Commands.Login;
using KuyumHesap.Application.Features.AuthFeature.Commands.Register;
using MediatR;
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
        [SwaggerDescriptionAttirbute("Login")]
        public async Task<ResponseDto<LoginCommandResponse>> LoginAsync(LoginCommandRequest request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost("register")]
        [SwaggerDescriptionAttirbute("Register")]
        public async Task<ResponseDto<RegisterCommandResponse>> RegisterAsync(RegisterCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
