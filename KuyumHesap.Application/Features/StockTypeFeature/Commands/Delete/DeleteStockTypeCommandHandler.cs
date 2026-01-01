using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockTypeFeature.Commands.Delete
{
    public class DeleteStockTypeCommandHandler : BaseHandler, IRequestHandler<DeleteStockTypeCommandRequest, ResponseDto<DeleteStockTypeCommandResponse>>
    {
        public DeleteStockTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteStockTypeCommandResponse>> Handle(DeleteStockTypeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<StockType>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            data.IsDeleted = true;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<StockType>().UpdateAsync(data);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteStockTypeCommandResponse>().Success();
        }
    }
}
