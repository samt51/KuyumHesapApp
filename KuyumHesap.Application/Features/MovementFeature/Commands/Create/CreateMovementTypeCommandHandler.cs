using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Commands.Create
{
    public class CreateMovementTypeCommandHandler : BaseHandler, IRequestHandler<CreateMovementTypeCommandRequest, ResponseDto<CreateMovementTypeCommandResponse>>
    {
        public CreateMovementTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateMovementTypeCommandResponse>> Handle(CreateMovementTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = mapper.Map<MovementType, CreateMovementTypeCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<MovementType>().AddAsync(data);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateMovementTypeCommandResponse>().Success();
        }
    }
}
