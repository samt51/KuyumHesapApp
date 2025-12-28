using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Command.Update
{
    public class UpdateAccountCommandHandler : BaseHandler, IRequestHandler<UpdateAccountCommandRequest, ResponseDto<UpdateAccountCommandResponse>>
    {
        public UpdateAccountCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateAccountCommandResponse>> Handle(UpdateAccountCommandRequest request, CancellationToken cancellationToken)
        {
           var data =  await unitOfWork.GetReadRepository<Account>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (string.IsNullOrEmpty(data.NationalIdNumber) && string.IsNullOrEmpty(data.MobilePhone))
            {
                var duplicate = await unitOfWork.GetReadRepository<Account>().GetAsync(x =>x.AccountName == request.AccountName&& x.Id != request.Id && !x.IsDeleted);
                if (duplicate != null)
                {
                    return new ResponseDto<UpdateAccountCommandResponse>().Fail($"{duplicate.AccountName} isminde bir hesap zaten mevcut. Lütfen bilgileri güncelleyin.");
                }
            }

            var mapData = mapper.Map<Account, UpdateAccountCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Account>().UpdateAsync(mapData, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateAccountCommandResponse>().Success();

        }
    }
}
