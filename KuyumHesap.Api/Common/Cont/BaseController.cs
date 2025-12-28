using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Common.Cont
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMediator mediator;

        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

    }
}
