using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.AccountTypeFeature.Command.Create
{
    public class CreateAccountTypeCommandHandler : BaseHandler, IRequestHandler<CreateAccountTypeCommandRequest, ResponseDto<CreateAccountTypeCommandResponse>>
    {
        public CreateAccountTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateAccountTypeCommandResponse>> Handle(CreateAccountTypeCommandRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.OpenTransactionAsync(cancellationToken);

            var map = mapper.Map<AccountType, CreateAccountTypeCommandRequest>(request);

            await unitOfWork.GetWriteRepository<AccountType>().AddAsync(map);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateAccountTypeCommandResponse>().Success();
        }
    }
}
