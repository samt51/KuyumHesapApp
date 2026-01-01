using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.StockFeature.Commands.Delete
{
    public class DeleteStockCommandHandler : BaseHandler, IRequestHandler<DeleteStockCommandRequest, ResponseDto<DeleteStockCommandResponse>>
    {
        public DeleteStockCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteStockCommandResponse>> Handle(DeleteStockCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Domain.Entities.Stock>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);
            data.IsDeleted = true;
            await unitOfWork.OpenTransactionAsync(cancellationToken);
            await unitOfWork.GetWriteRepository<Domain.Entities.Stock>().UpdateAsync(data);
            await unitOfWork.SaveAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return new ResponseDto<DeleteStockCommandResponse>().Success();
        }

    }
}
