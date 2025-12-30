using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Command.Delete
{
    public class DeleteAccountTypeCommandHandler : BaseHandler, IRequestHandler<DeleteAccountTypeCommandRequest, ResponseDto<DeleteAccountTypeCommandResponse>>
    {
        public DeleteAccountTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteAccountTypeCommandResponse>> Handle(DeleteAccountTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<AccountType>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            data.IsDeleted = true;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<AccountType>().UpdateAsync(data);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteAccountTypeCommandResponse>().Success();
        }
    }
}
