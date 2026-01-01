using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockGroupFeature.Commands.Create
{
    public class CreateStockGroupCommandHandler : BaseHandler, IRequestHandler<CreateStockGroupCommandRequest, ResponseDto<CreateStockGroupCommandResponse>>
    {
        public CreateStockGroupCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateStockGroupCommandResponse>> Handle(CreateStockGroupCommandRequest request, CancellationToken cancellationToken)
        {
            var mapEntity = mapper.Map<StockGroup, CreateStockGroupCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<StockGroup>().AddAsync(mapEntity, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<CreateStockGroupCommandResponse>().Success();
        }
    }
}
