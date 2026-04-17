using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Command.Delete
{
    public class DeletePageActionCommandHandler : BaseHandler, IRequestHandler<DeletePageActionCommandRequest, ResponseDto<DeletePageActionCommandResponse>>
    {
        public DeletePageActionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeletePageActionCommandResponse>> Handle(DeletePageActionCommandRequest request, CancellationToken cancellationToken)
        {
            var pageAction = await unitOfWork.GetReadRepository<PageAction>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            pageAction.IsDeleted = true;
            pageAction.ModifyDate = DateTime.Now;

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<PageAction>().UpdateAsync(pageAction);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeletePageActionCommandResponse>().Success();
        }
    }
}
