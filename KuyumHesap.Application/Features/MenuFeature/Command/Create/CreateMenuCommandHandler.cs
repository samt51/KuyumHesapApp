using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Command.Create
{
    public class CreateMenuCommandHandler : BaseHandler, IRequestHandler<CreateMenuCommandRequest, ResponseDto<CreateMenuCommandResponse>>
    {
        public CreateMenuCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateMenuCommandResponse>> Handle(CreateMenuCommandRequest request, CancellationToken cancellationToken)
        {

            var map = mapper.Map<Menu, CreateMenuCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<Menu>().AddAsync(map, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateMenuCommandResponse>().Success();
        }
    }
}
