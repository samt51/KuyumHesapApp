using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Delete
{
    public class DeleteReceiptCommandHandler : BaseHandler, IRequestHandler<DeleteReceiptCommandRequest, ResponseDto<DeleteReceiptCommandResponse>>
    {
        public DeleteReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteReceiptCommandResponse>> Handle(DeleteReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Receipt>().GetAsync(c => !c.IsDeleted && c.Id == request.Id,
                include: y => y.Include(y => y.Movements));


            data.IsDeleted = true;

            data.Movements.ForEach(m => m.IsDeleted = true);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Receipt>().UpdateAsync(data);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteReceiptCommandResponse>().Success();

        }
    }
}
