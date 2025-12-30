using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.TaskItemFeature.Commands.Delete
{
    public class DeleteTaskItemCommandHandler : BaseHandler, IRequestHandler<DeleteTaskItemCommandRequest, ResponseDto<DeleteTaskItemCommandResponse>>
    {
        public DeleteTaskItemCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteTaskItemCommandResponse>> Handle(DeleteTaskItemCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Domain.Entities.TaskItem>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);
            data.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Domain.Entities.TaskItem>().UpdateAsync(data);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return new ResponseDto<DeleteTaskItemCommandResponse>().Success();
        }
    }

}
