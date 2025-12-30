using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.TaskItemFeature.Commands.Create
{
    public class CreateTaskItemCommandHandler : BaseHandler, IRequestHandler<CreateTaskItemCommandRequest, ResponseDto<CreateTaskItemCommandResponse>>
    {
        public CreateTaskItemCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateTaskItemCommandResponse>> Handle(CreateTaskItemCommandRequest request, CancellationToken cancellationToken)
        {
            var mapData = mapper.Map<KuyumHesap.Domain.Entities.TaskItem, CreateTaskItemCommandRequest>(request);

            mapData.IsActive = true;

            await unitOfWork.GetWriteRepository<TaskItem>().AddAsync(mapData);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateTaskItemCommandResponse>().Success();
        }
    }
}
