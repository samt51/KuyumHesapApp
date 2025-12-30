using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Create
{
    public class CreateReceiptCommandHandler : BaseHandler, IRequestHandler<CreateReceiptCommandRequest, ResponseDto<CreateReceiptCommandResponse>>
    {
        public CreateReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateReceiptCommandResponse>> Handle(CreateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            var matualCashFlow = request.Movements.Where(x => x.TransactionTypeId == 8 && (x.CounterCurrencyId != null && x.CounterCurrencyId == x.ForeignCurrencyId)).ToList();

            var map = mapper.Map<Receipt, CreateReceiptCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Receipt>().AddAsync(map);

            await unitOfWork.SaveAsync(cancellationToken);

            if (matualCashFlow.Any())
            {
                foreach (var item in matualCashFlow)
                {
                    item.CounterCurrencyAmount = item.CounterExchangeRate;
                    item.ReceiptId = map.Id;
                }
            }

            await unitOfWork.GetWriteRepository<Movements>().AddRangeAsync(matualCashFlow);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            map.Movements = matualCashFlow;

            return new ResponseDto<CreateReceiptCommandResponse>().Success();


        }
    }
}
