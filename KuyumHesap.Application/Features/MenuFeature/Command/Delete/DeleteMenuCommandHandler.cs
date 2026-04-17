using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Command.Delete
{
    public class DeleteMenuCommandHandler : BaseHandler, IRequestHandler<DeleteMenuCommandRequest, ResponseDto<DeleteMenuCommandResponse>>
    {
        public DeleteMenuCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteMenuCommandResponse>> Handle(DeleteMenuCommandRequest request, CancellationToken cancellationToken)
        {
            var menu = await unitOfWork.GetReadRepository<Menu>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            menu.IsDeleted = true;
            menu.ModifyDate = DateTime.Now;

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<Menu>().UpdateAsync(menu);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteMenuCommandResponse>().Success();
        }
    }
}
