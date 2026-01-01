using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockFeature.Commands.Update
{
    public class UpdateStockCommandHandler : BaseHandler, IRequestHandler<UpdateStockCommandRequest, ResponseDto<UpdateStockCommandResponse>>
    {
        public UpdateStockCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateStockCommandResponse>> Handle(UpdateStockCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Stock>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var mappedData = mapper.Map(request, data);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Stock>().UpdateAsync(mappedData);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateStockCommandResponse>().Success();
        }
    }
}
