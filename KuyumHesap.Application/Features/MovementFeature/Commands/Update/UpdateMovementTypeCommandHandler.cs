using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Commands.Update
{
    public class UpdateMovementTypeCommandHandler : BaseHandler, IRequestHandler<UpdateMovementTypeCommandRequest, ResponseDto<UpdateMovementTypeCommandResponse>>
    {
        public UpdateMovementTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateMovementTypeCommandResponse>> Handle(UpdateMovementTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<MovementType>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var map = mapper.Map(request, data);

            await unitOfWork.GetWriteRepository<MovementType>().UpdateAsync(map);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateMovementTypeCommandResponse>().Success();
        }
    }
}
