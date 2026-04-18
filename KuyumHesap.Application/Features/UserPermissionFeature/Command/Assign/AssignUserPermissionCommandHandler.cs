using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.UserPermissionFeature.Command.Assign
{
    public class AssignUserPermissionCommandHandler : BaseHandler, IRequestHandler<AssignUserPermissionCommandRequest, ResponseDto<AssignUserPermissionCommandResponse>>
    {
        public AssignUserPermissionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<AssignUserPermissionCommandResponse>> Handle(AssignUserPermissionCommandRequest request, CancellationToken cancellationToken)
        {
            var userExists = await unitOfWork.GetReadRepository<Users>().FindAsync(x => x.Id == request.UserId && !x.IsDeleted);
            if (userExists is null)
            {
                return new ResponseDto<AssignUserPermissionCommandResponse>().Fail("Kullanıcı bulunamadı.");
            }

            var permissionExists = await unitOfWork.GetReadRepository<Permission>().FindAsync(x => x.Id == request.PermissionId && !x.IsDeleted);
            if (permissionExists is null)
            {
                return new ResponseDto<AssignUserPermissionCommandResponse>().Fail("Yetki bulunamadı.");
            }

            var exists = await unitOfWork.GetReadRepository<UserPermission>().FindAsync(
                x => x.UserId == request.UserId && x.PermissionId == request.PermissionId);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            if (exists is null)
            {
                await unitOfWork.GetWriteRepository<UserPermission>().AddAsync(new UserPermission
                {
                    UserId = request.UserId,
                    PermissionId = request.PermissionId,
                    IsAllowed = request.IsAllowed
                }, cancellationToken);
            }
            else
            {
                exists.IsDeleted = false;
                exists.IsAllowed = request.IsAllowed;
                exists.ModifyDate = DateTime.Now;
                await unitOfWork.GetWriteRepository<UserPermission>().UpdateAsync(exists);
            }

            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<AssignUserPermissionCommandResponse>().Success();
        }
    }
}
