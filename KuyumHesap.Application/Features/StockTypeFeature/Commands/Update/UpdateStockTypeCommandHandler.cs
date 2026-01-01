using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockTypeFeature.Commands.Update
{
    public class UpdateStockTypeCommandHandler : BaseHandler, IRequestHandler<UpdateStockTypeCommandRequest, ResponseDto<UpdateStockTypeCommandResponse>>
    {
        public UpdateStockTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateStockTypeCommandResponse>> Handle(UpdateStockTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<StockType>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var mapData = mapper.Map(request, data);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<StockType>().UpdateAsync(mapData);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateStockTypeCommandResponse>().Success();
        }
    }
}
