using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Commands.MutabakatUpdate
{
    public class MutabakatUpdateCommandHandler : BaseHandler, IRequestHandler<MutabakatUpdateCommandRequest, ResponseDto<MutabakatUpdateCommandResponse>>
    {
        public MutabakatUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<MutabakatUpdateCommandResponse>> Handle(MutabakatUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Movements>().GetAsync(x => x.Id == request.MovementId);

            data.IsReconciled = request.IsReconciled;

            await unitOfWork.OpenTransactionAsync(cancellationToken);


            await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(data, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<MutabakatUpdateCommandResponse>().Success();

        }

    }
}
