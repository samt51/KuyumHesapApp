using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Create
{
    public class CreateReceiptCommandHandler : BaseHandler, IRequestHandler<CreateReceiptCommandRequest, ResponseDto<CreateReceiptCommandResponse>>
    {
        int cashLastId = 0;
        public CreateReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateReceiptCommandResponse>> Handle(CreateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            await CreateCashModal(request);
            return new ResponseDto<CreateReceiptCommandResponse>().Success();
        }
        public async Task CreateCashModal(CreateReceiptCommandRequest request)
        {
            var map = mapper.Map<Receipt, CreateReceiptCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken: CancellationToken.None);

            map.AccountId = request.CurrentAccountId;

            map.CreatedByUserId = 1;
            map.ReceiptNumber = "";
            await unitOfWork.GetWriteRepository<Receipt>().AddAsync(map);


            await unitOfWork.SaveAsync();



            var mapMovement = mapper.Map<Movements, CreateMovementReceiptRequestDto>(request.CreateMovementReceiptRequestDtos);

            foreach (var movement in mapMovement)
            {
                var counterData = new Movements();

                //Satış Modunda ise 
                if (!map.IsCustomerReceipt)
                {
                    if (movement.TransactionTypeId == 1)
                    {
                        movement.ReceiptId = map.Id;
                        movement.CostAmount = movement.CounterCurrencyAmount;

                        await unitOfWork.GetWriteRepository<Movements>().AddAsync(movement);

                        await unitOfWork.SaveAsync();

                        var counterMap = mapper.Map<Movements, Movements>(movement);




                        counterMap.Id = 0;

                        counterMap.TransactionTypeId = 2;
                        counterMap.CounterCurrencyId = movement.ForeignCurrencyId;
                        counterMap.CounterTransactionId = movement.Id;
                        counterMap.CounterCurrencyAmount = movement.ForeignCurrencyAmount;
                        counterMap.CostAmount = movement.CounterCurrencyAmount;
                        counterMap.CounterTransactionId = movement.Id;

                        counterMap.Description = mapMovement.Where(y => y.TransactionTypeId == 2).Select(x => x.Description).FirstOrDefault() ?? "";

                        await unitOfWork.GetWriteRepository<Movements>().AddAsync(counterMap);

                        movement.CounterTransactionId = counterMap.Id;
                        await unitOfWork.SaveAsync();

                        movement.CounterTransactionId = counterMap.Id;

                        counterMap.CounterTransactionId = movement.Id;

                        await unitOfWork.SaveAsync();

                    }
                    if (movement.TransactionTypeId == 2)
                    {
                        var counterMap = mapper.Map<Movements, Movements>(movement);

                        counterMap.ReceiptId = map.Id;

                        counterMap.CounterCurrencyAmount = movement.ForeignCurrencyAmount;
                        counterMap.CounterCurrencyId = movement.ForeignCurrencyId;
                        counterMap.CostAmount = movement.CounterCurrencyAmount;



                        await unitOfWork.GetWriteRepository<Movements>().AddAsync(counterMap);

                        await unitOfWork.SaveAsync();



                        movement.Description = mapMovement.Where(y => y.TransactionTypeId == 1).Select(x => x.Description).FirstOrDefault() ?? "";

                        movement.CounterTransactionId = counterMap.Id;

                        movement.TransactionTypeId = 1;
                        movement.CostAmount = movement.CounterCurrencyAmount;
                        movement.ReceiptId = map.Id;

                        await unitOfWork.GetWriteRepository<Movements>().AddAsync(movement);

                        await unitOfWork.SaveAsync();

                        movement.CounterTransactionId = counterMap.Id;

                        counterMap.CounterTransactionId = movement.Id;

                        await unitOfWork.SaveAsync();
                    }

                }
            }
            await unitOfWork.CommitAsync();
        }
    }
}
