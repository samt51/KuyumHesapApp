using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Command.Update
{
    public class UpdatePermissionCommandHandler : BaseHandler, IRequestHandler<UpdatePermissionCommandRequest, ResponseDto<UpdatePermissionCommandResponse>>
    {
        public UpdatePermissionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdatePermissionCommandResponse>> Handle(UpdatePermissionCommandRequest request, CancellationToken cancellationToken)
        {
            var permission = await unitOfWork.GetReadRepository<Permission>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            permission.Code = request.Code;
            permission.Name = request.Name;
            permission.ModifyDate = DateTime.Now;

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<Permission>().UpdateAsync(permission);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdatePermissionCommandResponse>().Success();
        }
    }
}
