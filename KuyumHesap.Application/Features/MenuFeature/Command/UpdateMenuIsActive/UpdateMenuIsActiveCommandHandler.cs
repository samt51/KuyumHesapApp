using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Command.UpdateMenuIsActive
{
    public class UpdateMenuIsActiveCommandHandler : BaseHandler, IRequestHandler<UpdateMenuIsActiveCommandRequest, ResponseDto<UpdateMenuIsActiveCommandResponse>>
    {
        public UpdateMenuIsActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateMenuIsActiveCommandResponse>> Handle(UpdateMenuIsActiveCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Menu>().GetAsync(c => !c.IsDeleted && c.Id == request.Id);

            data.IsActive = request.IsActive;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Menu>().UpdateAsync(data);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateMenuIsActiveCommandResponse>().Success();
        }
    }
}
