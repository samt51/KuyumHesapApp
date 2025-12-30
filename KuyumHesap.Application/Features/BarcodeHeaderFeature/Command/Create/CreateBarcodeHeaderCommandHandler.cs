using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KuyumHesap.Application.Features.BarcodeHeaderFeature.Command.Create
{
    public class CreateBarcodeHeaderCommandHandler : BaseHandler, IRequestHandler<CreateBarcodeHeaderCommandRequest, ResponseDto<CreateBarcodeHeaderCommandResponse>>
    {
        public CreateBarcodeHeaderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateBarcodeHeaderCommandResponse>> Handle(CreateBarcodeHeaderCommandRequest request, CancellationToken cancellationToken)
        {
            var map = mapper.Map<BarcodeHeader, CreateBarcodeHeaderCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            var data = await unitOfWork.GetWriteRepository<BarcodeHeader>().AddAsync(map, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            var mapBarcodeDetail = mapper.Map<BarcodeDetail, BarcodeDetailRequestDto>(request.BarcodeDetails);

            foreach (var item in mapBarcodeDetail)
            {
                item.BarcodeHeaderId = data.Id;
            }

            await unitOfWork.GetWriteRepository<BarcodeDetail>().AddRangeAsync(mapBarcodeDetail);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateBarcodeHeaderCommandResponse>().Success();
        }
    }
}
