using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Command.Update
{
    public class UpdateAccountTypeCommandHandler : BaseHandler, IRequestHandler<UpdateAccountTypeCommandRequest, ResponseDto<UpdateAccountTypeCommandResponse>>
    {
        public UpdateAccountTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateAccountTypeCommandResponse>> Handle(UpdateAccountTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<AccountType>().GetAsync(c => c.Id == request.Id && !c.IsDeleted);
            var map = mapper.Map<AccountType, UpdateAccountTypeCommandRequest>(request);
            map.Id = data.Id;
            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<KuyumHesap.Domain.Entities.AccountType>().UpdateAsync(map);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return new ResponseDto<UpdateAccountTypeCommandResponse>().Success();
        }

    }
}
