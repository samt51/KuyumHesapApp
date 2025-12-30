using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.UpdateAgreement
{
    public class UpdateAgreementCommandHandler : BaseHandler, IRequestHandler<UpdateAgreementCommandRequest, ResponseDto<UpdateAgreementCommandResponse>>
    {
        public UpdateAgreementCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateAgreementCommandResponse>> Handle(UpdateAgreementCommandRequest request, CancellationToken cancellationToken)
        {
            var movementData = await unitOfWork.GetReadRepository<Movements>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            movementData.IsReconciled = request.Agreement;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(movementData);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateAgreementCommandResponse>().Success();
        }
    }
}
