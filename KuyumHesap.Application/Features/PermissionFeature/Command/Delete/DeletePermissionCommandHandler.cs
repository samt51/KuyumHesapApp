using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Command.Delete
{
    public class DeletePermissionCommandHandler : BaseHandler, IRequestHandler<DeletePermissionCommandRequest, ResponseDto<DeletePermissionCommandResponse>>
    {
        public DeletePermissionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeletePermissionCommandResponse>> Handle(DeletePermissionCommandRequest request, CancellationToken cancellationToken)
        {
            var permission = await unitOfWork.GetReadRepository<Permission>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            permission.IsDeleted = true;
            permission.ModifyDate = DateTime.Now;

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<Permission>().UpdateAsync(permission);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeletePermissionCommandResponse>().Success();
        }
    }
}
