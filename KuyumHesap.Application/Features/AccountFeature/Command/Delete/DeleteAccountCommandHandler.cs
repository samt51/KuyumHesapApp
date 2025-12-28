using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.AccountFeature.Command.Delete
{
    public class DeleteAccountCommandHandler : BaseHandler, IRequestHandler<DeleteAccountCommandRequest, ResponseDto<DeleteAccountCommandResponse>>
    {
        public DeleteAccountCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteAccountCommandResponse>> Handle(DeleteAccountCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Domain.Entities.Account>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            data.IsDeleted = true;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Domain.Entities.Account>().UpdateAsync(data, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);  

            await unitOfWork.CommitAsync(cancellationToken);        

            return new ResponseDto<DeleteAccountCommandResponse>().Success();   
        }
    }
}
