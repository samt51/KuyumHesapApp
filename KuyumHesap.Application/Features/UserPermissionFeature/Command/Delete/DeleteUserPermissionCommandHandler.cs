using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.UserPermissionFeature.Command.Delete
{
    public class DeleteUserPermissionCommandHandler : BaseHandler, IRequestHandler<DeleteUserPermissionCommandRequest, ResponseDto<DeleteUserPermissionCommandResponse>>
    {
        public DeleteUserPermissionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteUserPermissionCommandResponse>> Handle(DeleteUserPermissionCommandRequest request, CancellationToken cancellationToken)
        {
            var userPermission = await unitOfWork.GetReadRepository<UserPermission>().GetAsync(
                x => x.UserId == request.UserId && x.PermissionId == request.PermissionId && !x.IsDeleted);

            userPermission.IsDeleted = true;
            userPermission.ModifyDate = DateTime.Now;

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<UserPermission>().UpdateAsync(userPermission);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteUserPermissionCommandResponse>().Success();
        }
    }
}
