using KuyumHesap.Api.Common.Cont;
using MediatR;

namespace KuyumHesap.Api.Controllers.ExchangeCont
{
    public class CureController : BaseController
    {
        private readonly IMediator _mediator;
        public CureController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

    }
}
