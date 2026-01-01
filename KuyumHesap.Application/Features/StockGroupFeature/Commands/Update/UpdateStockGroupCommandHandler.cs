using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockGroupFeature.Commands.Update
{
    public class UpdateStockGroupCommandHandler : BaseHandler, IRequestHandler<UpdateStockGroupCommandRequest, ResponseDto<UpdateStockGroupCommandResponse>>
    {
        public UpdateStockGroupCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateStockGroupCommandResponse>> Handle(UpdateStockGroupCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<StockGroup>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var mapData = mapper.Map(request, data);

            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<StockGroup>().UpdateAsync(mapData);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateStockGroupCommandResponse>().Success();
        }
    }
}
