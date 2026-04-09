using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Commands.Roles.Create
{
    public class CreateRolesCommandHandler : BaseHandler, IRequestHandler<CreateRolesCommandRequest, ResponseDto<CreateRolesCommandResponse>>
    {
        public CreateRolesCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateRolesCommandResponse>> Handle(CreateRolesCommandRequest request, CancellationToken cancellationToken)
        {
            var mapData = mapper.Map<KuyumHesap.Domain.Entities.Roles, CreateRolesCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<KuyumHesap.Domain.Entities.Roles>().AddAsync(mapData);

            await unitOfWork.SaveAsync(cancellationToken);

            return new ResponseDto<CreateRolesCommandResponse>().Success();
        }
    }
}
