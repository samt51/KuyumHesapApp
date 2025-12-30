using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Command.Delete
{
    public class DeleteBarcodeHeaderCommandHandler : BaseHandler, IRequestHandler<DeleteBarcodeHeaderCommandRequest, ResponseDto<DeleteBarcodeHeaderCommandResponse>>
    {
        public DeleteBarcodeHeaderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteBarcodeHeaderCommandResponse>> Handle(DeleteBarcodeHeaderCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<BarcodeHeader>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            data.IsDeleted = true;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<BarcodeHeader>().UpdateAsync(data, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteBarcodeHeaderCommandResponse>().Success();
        }
    }
}
