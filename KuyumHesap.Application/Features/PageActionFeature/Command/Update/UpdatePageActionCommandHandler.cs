using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Command.Update
{
    public class UpdatePageActionCommandHandler : BaseHandler, IRequestHandler<UpdatePageActionCommandRequest, ResponseDto<UpdatePageActionCommandResponse>>
    {
        public UpdatePageActionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdatePageActionCommandResponse>> Handle(UpdatePageActionCommandRequest request, CancellationToken cancellationToken)
        {
            var pageAction = await unitOfWork.GetReadRepository<PageAction>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            pageAction.Name = request.Name;
            pageAction.Code = request.Code;
            pageAction.PageCode = request.PageCode;
            pageAction.IconUrl = request.IconUrl;
            pageAction.OrderNo = request.OrderNo;
            pageAction.RequiredPermissionCode = request.RequiredPermissionCode;
            pageAction.ModifyDate = DateTime.Now;

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<PageAction>().UpdateAsync(pageAction);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdatePageActionCommandResponse>().Success();
        }
    }
}
