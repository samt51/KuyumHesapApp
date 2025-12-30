using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.TaskItemFeature.Commands.Update
{
    public class UpdateTaskItemCommandHandler : BaseHandler, IRequestHandler<UpdateTaskItemCommandRequest, ResponseDto<UpdateTaskItemCommandResponse>>
    {
        public UpdateTaskItemCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateTaskItemCommandResponse>> Handle(UpdateTaskItemCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<TaskItem>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var map=mapper.Map(request, data);  

            await unitOfWork.GetWriteRepository<TaskItem>().UpdateAsync(map);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);    

            return new ResponseDto<UpdateTaskItemCommandResponse>().Success(); 
        }
    }
}
