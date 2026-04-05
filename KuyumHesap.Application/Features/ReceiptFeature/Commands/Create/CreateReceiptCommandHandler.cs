using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Create
{
    public class CreateReceiptCommandHandler : BaseHandler, IRequestHandler<CreateReceiptCommandRequest, ResponseDto<CreateReceiptCommandResponse>>
    {
        public CreateReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateReceiptCommandResponse>> Handle(CreateReceiptCommandRequest request, CancellationToken cancellationToken)
        {

            await unitOfWork.OpenTransactionAsync(cancellationToken);
        
            // Request'i tek çaðrýda Receipt entity'sine map et
            var receipt = mapper.Map<Receipt, CreateReceiptCommandRequest>(request);


            receipt.CreatedByUserId = 1;

            await unitOfWork.GetWriteRepository<Receipt>().AddAsync(receipt);

            await unitOfWork.SaveAsync();

            // Eðer hareket DTO'larý geldiyse, Movements listesine map et ve Receipt'e ata
            if (request.CreateMovementReceiptRequestDtos != null && request.CreateMovementReceiptRequestDtos.Any())
            {
                var movements = mapper.Map<Movements, CreateMovementReceiptRequestDto>(request.CreateMovementReceiptRequestDtos);

                


                for (int i = 0; i < movements.Count; i += 2)
                {
                    var movementData = movements[i];
                    var movementDataTwo = movements[i + 1];

                    movementData.ReceiptId = receipt.Id;
                    movementData.CreatedByUserId = 1;

                    await unitOfWork.GetWriteRepository<Movements>().AddAsync(movementData);

                    await unitOfWork.SaveAsync();

                    movementDataTwo.ReceiptId = receipt.Id;
                    movementDataTwo.CounterTransactionId = movementData.Id;
                    movementDataTwo.CreatedByUserId = 1;

                    await unitOfWork.GetWriteRepository<Movements>().AddAsync(movementDataTwo);

                    await unitOfWork.SaveAsync();

                    movementData.CounterTransactionId = movementDataTwo.Id;

                    await unitOfWork.GetWriteRepository<Movements>().UpdateAsync(movementData);
                    await unitOfWork.SaveAsync();
                }
     
            }
        
            await unitOfWork.CommitAsync();

            return new ResponseDto<CreateReceiptCommandResponse>().Success();
        }
    }
}
