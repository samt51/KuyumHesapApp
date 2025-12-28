using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;


namespace KuyumHesap.Application.Features.AccountFeature.Command.Create
{
    internal class CreateAccountCommandHandler : BaseHandler, IRequestHandler<CreateAccountCommandRequest, ResponseDto<CreateAccountCommandResponse>>
    {
        public CreateAccountCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateAccountCommandResponse>> Handle(CreateAccountCommandRequest request, CancellationToken cancellationToken)
        {
            var accountByAccountName = await unitOfWork.GetReadRepository<Account>().GetAsync(x => x.AccountName == request.AccountName && !x.IsDeleted);

            if (string.IsNullOrWhiteSpace(accountByAccountName.NationalIdNumber) && string.IsNullOrWhiteSpace(accountByAccountName?.MobilePhone))
            {
                return new ResponseDto<CreateAccountCommandResponse>().Fail($"{accountByAccountName?.AccountName} isminde bir hesap zaten mevcut. Lütfen bilgileri güncelleyin.");
            }

            var mapData = mapper.Map<Account,CreateAccountCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Account>().AddAsync(mapData, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);


            return new ResponseDto<CreateAccountCommandResponse>().Success();

        }
    }
}
