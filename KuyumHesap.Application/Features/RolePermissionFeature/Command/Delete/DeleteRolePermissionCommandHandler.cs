using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.RolePermissionFeature.Command.Delete
{
    public class DeleteRolePermissionCommandHandler : BaseHandler, IRequestHandler<DeleteRolePermissionCommandRequest, ResponseDto<DeleteRolePermissionCommandResponse>>
    {
        public DeleteRolePermissionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteRolePermissionCommandResponse>> Handle(DeleteRolePermissionCommandRequest request, CancellationToken cancellationToken)
        {
            var rolePermission = await unitOfWork.GetReadRepository<RolePermission>().GetAsync(
                x => x.RoleId == request.RoleId && x.PermissionId == request.PermissionId && !x.IsDeleted);

            rolePermission.IsDeleted = true;
            rolePermission.ModifyDate = DateTime.Now;

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<RolePermission>().UpdateAsync(rolePermission);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteRolePermissionCommandResponse>().Success();
        }
    }
}
