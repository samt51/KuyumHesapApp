using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Extensions;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Create
{
    public class CreateReceiptCommandHandler : BaseHandler, IRequestHandler<CreateReceiptCommandRequest, ResponseDto<CreateReceiptCommandResponse>>
    {
        int cashLastId = 0;
        int accounId;
        int currentAccounId = 0;
        public CreateReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateReceiptCommandResponse>> Handle(CreateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            var receipt = await CreateCashModal(request, cancellationToken);
            return new ResponseDto<CreateReceiptCommandResponse>().Success(new CreateReceiptCommandResponse 
            { 
                Id = receipt?.Id ?? 0,
                ReceiptNumber = receipt?.ReceiptNumber ?? string.Empty
            });
        }

        public async Task<Receipt> CreateCashModal(CreateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var settings = await unitOfWork.GetReadRepository<Setting>().GetAllAsync(x => !x.IsDeleted);
                
                int defaultCashAccountId = int.TryParse(settings.FirstOrDefault(s => s.Key == "DefaultCashAccountId")?.Value, out var dcid) ? dcid : 1;
                int defaultDiscountAccountId = int.TryParse(settings.FirstOrDefault(s => s.Key == "DefaultDiscountAccountId")?.Value, out var ddid) ? ddid : 3;

                accounId = request.AccountId;
                currentAccounId = request.CurrentAccountId;
                // Generate and map receipt
                request.ReceiptNumber = HelpersExtension.GenerateUniqueReceiptNumber();

                var receipt = mapper.Map<Receipt, CreateReceiptCommandRequest>(request);

                await unitOfWork.OpenTransactionAsync(cancellationToken);

                receipt.AccountId = request.CurrentAccountId;

                receipt.CreatedByUserId = 1;

                // Add receipt and save to get generated Id
                await unitOfWork.GetWriteRepository<Receipt>().AddAsync(receipt);
                await unitOfWork.SaveAsync(cancellationToken);

                // Map incoming DTOs to Movements (assumes mapper generic signature as in original)
                var movements = mapper.Map<Movements, CreateMovementReceiptRequestDto>(request.CreateMovementReceiptRequestDtos);

                foreach (var movement in movements)
                {
                    if (!receipt.IsCustomerReceipt)
                    {
                        // Ensure basic fields set for movement before add
                        movement.ReceiptId = receipt.Id;
                        movement.CostAmount = movement.CounterCurrencyAmount;
                        request.AccountId = defaultCashAccountId;
                        
                        // Delegate handling by transaction type
                        await ProcessMovementPairAsync(movement, request, receipt, movements, defaultDiscountAccountId, cancellationToken);
                    }
                    else
                    {
                        movement.ReceiptId = receipt.Id;
                        await unitOfWork.GetWriteRepository<Movements>().AddAsync(movement);
                    }
                }

                await unitOfWork.SaveAsync(cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return receipt;
            }
            catch (Exception)
            {
                // Attempt rollback if available and rethrow (simplified to preserve original behavior)
                try
                {
                    await unitOfWork.RollBackAsync(cancellationToken);
                }
                catch
                {
                    // ignore rollback failures, preserve original exception
                }

                throw;
            }
        }

        private async Task ProcessMovementPairAsync(Movements movement, CreateReceiptCommandRequest request, Receipt receipt, IEnumerable<Movements> allMovements, int defaultDiscountAccountId, CancellationToken cancellationToken)
        {
            // Use transaction-type pairs to determine counter transaction type and mapping rules.
            // This consolidates the repetitive logic in the original code.
            switch (movement.TransactionTypeId)
            {
                case 1:
                    await HandlePrimaryThenCounterAsync(movement, request, receipt, counterTransactionType: 2, descriptionSourceType: 2, 1, defaultDiscountAccountId, cancellationToken);
                    break;
                case 2:
                    await HandleCounterThenPrimaryAsync(movement, request, receipt, primaryTransactionType: 1, descriptionSourceType: 1, 2, defaultDiscountAccountId, cancellationToken);
                    break;
                case 5:
                    await HandlePrimaryThenCounterAsync(movement, request, receipt, counterTransactionType: 6, descriptionSourceType: 6, 5, defaultDiscountAccountId, cancellationToken);
                    break;
                case 6:
                    await HandleCounterThenPrimaryAsync(movement, request, receipt, primaryTransactionType: 5, descriptionSourceType: 5, 6, defaultDiscountAccountId, cancellationToken);
                    break;
                case 7:
                    await HandleCounterThenPrimaryAsync(movement, request, receipt, primaryTransactionType: 8, descriptionSourceType: 8, 7, defaultDiscountAccountId, cancellationToken);
                    break;
                case 8:
                    await HandleCounterThenPrimaryAsync(movement, request, receipt, primaryTransactionType: 7, descriptionSourceType: 7, 8, defaultDiscountAccountId, cancellationToken);
                    break;
                default:
                    // If unknown transaction type, just add movement
                    await unitOfWork.GetWriteRepository<Movements>().AddAsync(movement);
                    await unitOfWork.SaveAsync(cancellationToken);
                    break;
            }

            // Local helpers below capture the pattern used repeatedly in the old code.
            async Task HandlePrimaryThenCounterAsync(Movements primary, CreateReceiptCommandRequest req, Receipt rec, int counterTransactionType, int descriptionSourceType, int isProccessingNo, int discountAccountId, CancellationToken ct)
            {
                // Add primary movement
                primary.AccountId = req.CurrentAccountId;
                primary.ReceiptId = rec.Id;
                primary.CostAmount = primary.CounterCurrencyAmount;
                await unitOfWork.GetWriteRepository<Movements>().AddAsync(primary);
                await unitOfWork.SaveAsync(ct);

                // Create counter copy
                var counter = mapper.Map<Movements, Movements>(primary);
                counter.Id = 0;
                counter.AccountId = counterTransactionType == 6 ? discountAccountId : req.AccountId;
                counter.TransactionTypeId = counterTransactionType;
                counter.CounterCurrencyId = primary.ForeignCurrencyId;
                counter.CounterTransactionId = primary.Id;
                counter.CounterCurrencyAmount = primary.ForeignCurrencyAmount;
                counter.CostAmount = primary.CounterCurrencyAmount;
                counter.IsDeleted = true;
                counter.Description = allMovements.Where(y => y.TransactionTypeId == descriptionSourceType).Select(x => x.Description).FirstOrDefault() ?? "";

                await unitOfWork.GetWriteRepository<Movements>().AddAsync(counter);
                await unitOfWork.SaveAsync(ct);

                // Link both sides
                primary.CounterTransactionId = counter.Id;
                counter.CounterTransactionId = primary.Id;

                // Save links
                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(primary);
                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(counter);
                await unitOfWork.SaveAsync(ct);
            }

            async Task HandleCounterThenPrimaryAsync(Movements counterDefinition, CreateReceiptCommandRequest req, Receipt rec, int primaryTransactionType, int descriptionSourceType, int isProccessingNo, int discountAccountId, CancellationToken ct)
            {
                // Create the counter (first)
                var counter = mapper.Map<Movements, Movements>(counterDefinition);
                counter.AccountId = primaryTransactionType == 5 || primaryTransactionType == 8 || primaryTransactionType == 7 ? currentAccounId : accounId;

                if (isProccessingNo == 2)
                {
                    counter.AccountId = req.CurrentAccountId;
                }
                counter.ReceiptId = rec.Id;
                counter.CounterCurrencyAmount  = counterDefinition.CounterCurrencyAmount;
                counter.CounterCurrencyId = counterDefinition.CounterCurrencyId;
                counter.CostAmount = counterDefinition.CounterCurrencyAmount;



                await unitOfWork.GetWriteRepository<Movements>().AddAsync(counter);
                await unitOfWork.SaveAsync(ct);

                // Prepare primary side from incoming data
                counterDefinition.Description = allMovements.Where(y => y.TransactionTypeId == descriptionSourceType).Select(x => x.Description).FirstOrDefault() ?? "";
                counterDefinition.CounterTransactionId = counter.Id;
                counterDefinition.TransactionTypeId = primaryTransactionType;
                counterDefinition.CostAmount = counterDefinition.CounterCurrencyAmount;
                counterDefinition.ReceiptId = rec.Id;
                counterDefinition.AccountId = primaryTransactionType == 5 ? discountAccountId : req.AccountId;
                counterDefinition.IsDeleted = true;
                counterDefinition.CounterCurrencyAmount = counter.ForeignCurrencyAmount;
                counterDefinition.CounterCurrencyId = counter.ForeignCurrencyId;
             

                await unitOfWork.GetWriteRepository<Movements>().AddAsync(counterDefinition);
                await unitOfWork.SaveAsync(ct);

                // Link both sides
                counterDefinition.CounterTransactionId = counter.Id;
                counter.CounterTransactionId = counterDefinition.Id;

                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(counter);
                await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(counterDefinition);
                await unitOfWork.SaveAsync(ct);
            }
        }
    }
}
