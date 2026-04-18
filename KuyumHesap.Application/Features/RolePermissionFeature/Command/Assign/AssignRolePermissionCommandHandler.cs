using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.RolePermissionFeature.Command.Assign
{
    public class AssignRolePermissionCommandHandler : BaseHandler, IRequestHandler<AssignRolePermissionCommandRequest, ResponseDto<AssignRolePermissionCommandResponse>>
    {
        public AssignRolePermissionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<AssignRolePermissionCommandResponse>> Handle(AssignRolePermissionCommandRequest request, CancellationToken cancellationToken)
        {
            var roleExists = await unitOfWork.GetReadRepository<Roles>().FindAsync(x => x.Id == request.RoleId && !x.IsDeleted);
            if (roleExists is null)
            {
                return new ResponseDto<AssignRolePermissionCommandResponse>().Fail("Rol bulunamadı.");
            }

            var permissionExists = await unitOfWork.GetReadRepository<Permission>().FindAsync(x => x.Id == request.PermissionId && !x.IsDeleted);
            if (permissionExists is null)
            {
                return new ResponseDto<AssignRolePermissionCommandResponse>().Fail("Yetki bulunamadı.");
            }

            var exists = await unitOfWork.GetReadRepository<RolePermission>().FindAsync(
                x => x.RoleId == request.RoleId && x.PermissionId == request.PermissionId);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            if (exists is null)
            {
                await unitOfWork.GetWriteRepository<RolePermission>().AddAsync(new RolePermission
                {
                    RoleId = request.RoleId,
                    PermissionId = request.PermissionId
                }, cancellationToken);
            }
            else if (exists.IsDeleted)
            {
                exists.IsDeleted = false;
                exists.ModifyDate = DateTime.Now;
                await unitOfWork.GetWriteRepository<RolePermission>().UpdateAsync(exists);
            }

            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<AssignRolePermissionCommandResponse>().Success();
        }
    }
}
