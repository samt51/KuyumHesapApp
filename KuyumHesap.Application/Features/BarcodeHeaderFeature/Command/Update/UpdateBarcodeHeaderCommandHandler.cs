using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Command.Update
{
    public class UpdateBarcodeHeaderCommandHandler : BaseHandler, IRequestHandler<UpdateBarcodeHeaderCommandRequest, ResponseDto<UpdateBarcodeHeaderCommandResponse>>
    {
        public UpdateBarcodeHeaderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateBarcodeHeaderCommandResponse>> Handle(UpdateBarcodeHeaderCommandRequest request, CancellationToken cancellationToken)
        {
            var getBarcodeDetailById = await unitOfWork.GetReadRepository<BarcodeDetail>().FindAsync(x => !x.IsDeleted && x.BarcodeHeaderId == request.Id);

            getBarcodeDetailById.IsDeleted = true;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<BarcodeDetail>().UpdateAsync(getBarcodeDetailById);

            var data = await unitOfWork.GetReadRepository<BarcodeHeader>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var map = mapper.Map<BarcodeHeader, UpdateBarcodeHeaderCommandRequest>(request);

            await unitOfWork.GetWriteRepository<BarcodeHeader>().UpdateAsync(map);

            var mapBarcodeDetail = mapper.Map<BarcodeDetail, BarcodeDetailRequestDto>(request.barcodeDetails);

            foreach (var item in mapBarcodeDetail)
            {
                item.BarcodeHeaderId = data.Id;
            }

            await unitOfWork.GetWriteRepository<BarcodeDetail>().AddRangeAsync(mapBarcodeDetail);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateBarcodeHeaderCommandResponse>().Success();
        }
    }
}
