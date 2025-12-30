using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Delete
{
    public class DeleteReceiptCommandHandler : BaseHandler, IRequestHandler<DeleteReceiptCommandRequest, ResponseDto<DeleteReceiptCommandResponse>>
    {
        public DeleteReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteReceiptCommandResponse>> Handle(DeleteReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            var movementData = await unitOfWork.GetReadRepository<Movements>().GetAllAsync(y => !y.IsDeleted && y.ReceiptId == request.Id);

            foreach (var item in movementData)
            {
                item.IsDeleted = true;
                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(item);
            }

            var receiptData = await unitOfWork.GetReadRepository<Receipt>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            receiptData.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Receipt>().UpdateAsync(receiptData);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteReceiptCommandResponse>().Success();

        }
    }
}
