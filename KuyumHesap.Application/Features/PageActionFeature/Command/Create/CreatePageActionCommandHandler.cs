using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Command.Create
{
    public class CreatePageActionCommandHandler : BaseHandler, IRequestHandler<CreatePageActionCommandRequest, ResponseDto<CreatePageActionCommandResponse>>
    {
        public CreatePageActionCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreatePageActionCommandResponse>> Handle(CreatePageActionCommandRequest request, CancellationToken cancellationToken)
        {
            var exists = await unitOfWork.GetReadRepository<PageAction>().FindAsync(
                x => !x.IsDeleted && x.PageCode == request.PageCode && x.Code == request.Code);

            if (exists is not null)
            {
                return new ResponseDto<CreatePageActionCommandResponse>().Fail("Bu sayfa aksiyonu zaten tanımlı.");
            }

            var pageAction = new PageAction
            {
                Name = request.Name,
                Code = request.Code,
                PageCode = request.PageCode,
                IconUrl = request.IconUrl,
                OrderNo = request.OrderNo,
                RequiredPermissionCode = request.RequiredPermissionCode
            };

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<PageAction>().AddAsync(pageAction, cancellationToken);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreatePageActionCommandResponse>().Success();
        }
    }
}
