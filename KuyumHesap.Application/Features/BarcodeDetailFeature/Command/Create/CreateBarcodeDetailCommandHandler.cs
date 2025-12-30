using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeDetailFeature.Command.Create
{
    public class CreateBarcodeDetailCommandHandler : BaseHandler, IRequestHandler<CreateBarcodeDetailCommandRequest, ResponseDto<CreateBarcodeDetailCommandResponse>>
    {
        public CreateBarcodeDetailCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateBarcodeDetailCommandResponse>> Handle(CreateBarcodeDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var map = mapper.Map<BarcodeDetail, CreateBarcodeDetailCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<BarcodeDetail>().AddAsync(map, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateBarcodeDetailCommandResponse>().Success();
        }
    }
}
