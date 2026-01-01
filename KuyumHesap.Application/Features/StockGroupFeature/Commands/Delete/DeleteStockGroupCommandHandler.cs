using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockGroupFeature.Commands.Delete
{
    public class DeleteStockGroupCommandHandler : BaseHandler, IRequestHandler<DeleteStockGroupCommandRequest, ResponseDto<DeleteStockGroupCommandResponse>>
    {
        public DeleteStockGroupCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteStockGroupCommandResponse>> Handle(DeleteStockGroupCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<StockGroup>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            data.IsDeleted = true;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<StockGroup>().UpdateAsync(data);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteStockGroupCommandResponse>().Success();
        }
    }
}
