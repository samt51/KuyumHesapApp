using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Commands.Delete
{
    public class DeleteExchangeCommandHandler : BaseHandler, IRequestHandler<DeleteExchangeCommandRequest, ResponseDto<DeleteExchangeCommandResponse>>
    {
        public DeleteExchangeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteExchangeCommandResponse>> Handle(DeleteExchangeCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Currency>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            data.IsDeleted = true;

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Currency>().UpdateAsync(data);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<DeleteExchangeCommandResponse>().Success();
        }
    }
}
