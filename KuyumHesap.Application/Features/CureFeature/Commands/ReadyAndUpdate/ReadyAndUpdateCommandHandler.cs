using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.CureFeature.Commands.ReadyAndUpdate
{
    public class ReadyAndUpdateCommandHandler : BaseHandler, IRequestHandler<ReadyAndUpdateCommandRequest, ResponseDto<ReadyAndUpdateCommandResponse>>
    {
        public ReadyAndUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ResponseDto<ReadyAndUpdateCommandResponse>> Handle(ReadyAndUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
