using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Command.Update
{
    public class UpdateMenuCommandHandler : BaseHandler, IRequestHandler<UpdateMenuCommandRequest, ResponseDto<UpdateMenuCommandResponse>>
    {
        public UpdateMenuCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateMenuCommandResponse>> Handle(UpdateMenuCommandRequest request, CancellationToken cancellationToken)
        {
            var menu = await unitOfWork.GetReadRepository<Menu>().GetAsync(x => x.Id == request.Id && !x.IsDeleted, enableTracking: true);

            menu.ParentId = request.ParentId;
            menu.Name = request.Name;
            menu.Code = request.Code;
            menu.Url = request.Url;
            menu.IconUrl = request.IconUrl;
            menu.OrderNo = request.OrderNo;
            menu.RequeiredPermissionCode = request.RequeiredPermissionCode;
            menu.ModifyDate = DateTime.Now;

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<Menu>().UpdateAsync(menu);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateMenuCommandResponse>().Success();
        }
    }
}
