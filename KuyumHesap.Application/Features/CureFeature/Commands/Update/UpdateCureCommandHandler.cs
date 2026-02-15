using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Aut;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.CureFeature.Commands.Update
{
    public class UpdateCureCommandHandler : BaseHandler, IRequestHandler<UpdateCureCommandRequest, ResponseDto<UpdateCureCommandResponse>>
    {
        private readonly IKurGuncellemeService _kurGuncellemeService;
        public UpdateCureCommandHandler(IKurGuncellemeService kurGuncellemeService, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _kurGuncellemeService = kurGuncellemeService;   
        }

        public async Task<ResponseDto<UpdateCureCommandResponse>> Handle(UpdateCureCommandRequest request, CancellationToken cancellationToken)
        {
            var data = new List<Domain.Entities.ExchangeRate>();
            return new ResponseDto<UpdateCureCommandResponse>().Success();  
        }
    }
}
