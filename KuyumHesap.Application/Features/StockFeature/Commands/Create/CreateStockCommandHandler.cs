using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockFeature.Commands.Create
{
    public class CreateStockCommandHandler : BaseHandler, IRequestHandler<CreateStockCommandRequest, ResponseDto<CreateStockCommandResponse>>
    {
        public CreateStockCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateStockCommandResponse>> Handle(CreateStockCommandRequest request, CancellationToken cancellationToken)
        {
            var mapData = mapper.Map<Stock, CreateStockCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Stock>().AddAsync(mapData, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);  

            await unitOfWork.CommitAsync(cancellationToken);    

            return new ResponseDto<CreateStockCommandResponse>().Success();
        }
    }
}
