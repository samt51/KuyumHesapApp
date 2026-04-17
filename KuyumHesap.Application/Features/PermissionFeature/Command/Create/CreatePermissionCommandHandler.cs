using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Command.Create
{
    public class CreatePermissionCommandHandler : BaseHandler, IRequestHandler<CreatePermissionCommandRequest, ResponseDto<CreatePermissionCommandResponse>>
    {
        public CreatePermissionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreatePermissionCommandResponse>> Handle(CreatePermissionCommandRequest request, CancellationToken cancellationToken)
        {
            var exists = await unitOfWork.GetReadRepository<Permission>().FindAsync(x => x.Code == request.Code && !x.IsDeleted);
            if (exists is not null)
            {
                return new ResponseDto<CreatePermissionCommandResponse>().Fail("Bu yetki kodu zaten tanımlı.");
            }

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<Permission>().AddAsync(new Permission { Code = request.Code, Name = request.Name }, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreatePermissionCommandResponse>().Success();
        }
    }
}
