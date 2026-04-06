using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Commands.Delete
{
    public class DeleteMovementCommandHandler : BaseHandler, IRequestHandler<DeleteMovementCommandRequest, ResponseDto<DeleteMovementCommandResponse>>
    {
        public DeleteMovementCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteMovementCommandResponse>> Handle(DeleteMovementCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Movements>().GetAsync(x => x.Id == request.MovementId && !x.IsDeleted);

            data.IsDeleted = true;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(data);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteMovementCommandResponse>().Success();


        }
    }
}
