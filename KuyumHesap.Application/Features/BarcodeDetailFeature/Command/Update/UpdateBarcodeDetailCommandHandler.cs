using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using System.Security.Cryptography;
using System.Xml;

namespace KuyumHesap.Application.Features.BarcodeDetailFeature.Command.Update
{
    public class UpdateBarcodeDetailCommandHandler : BaseHandler, IRequestHandler<UpdateBarcodeDetailCommandRequest, ResponseDto<UpdateBarcodeDetailCommandResponse>>
    {
        public UpdateBarcodeDetailCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateBarcodeDetailCommandResponse>> Handle(UpdateBarcodeDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<BarcodeDetail>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            data.PositionX = request.PositionX;
            data.PositionY = request.PositionY;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<BarcodeDetail>().UpdateAsync(data, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateBarcodeDetailCommandResponse>().Success();
        }
    }
}
