using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Commands.Roles.Update
{
    public class UpdateRolesCommandHandler : BaseHandler, IRequestHandler<UpdateRolesCommandRequest, ResponseDto<UpdateRolesCommandResponse>>
    {
        public UpdateRolesCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateRolesCommandResponse>> Handle(UpdateRolesCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<KuyumHesap.Domain.Entities.Roles>().GetAsync(c => !c.IsDeleted && c.Id == request.Id);

            var mapData = mapper.Map<KuyumHesap.Domain.Entities.Roles, UpdateRolesCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<KuyumHesap.Domain.Entities.Roles>().UpdateAsync(mapData);

            await unitOfWork.SaveAsync();

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateRolesCommandResponse>().Success();
        }
    }
}
