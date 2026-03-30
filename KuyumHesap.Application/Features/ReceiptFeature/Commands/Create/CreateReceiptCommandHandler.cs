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
        public CreateReceiptCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateReceiptCommandResponse>> Handle(CreateReceiptCommandRequest request, CancellationToken cancellationToken)
        {
            // Request'i tek çağrıda Receipt entity'sine map et
            var receipt = mapper.Map<Receipt, CreateReceiptCommandRequest>(request);

            await unitOfWork.OpenTransactionAsync(cancellationToken);

            await unitOfWork.GetWriteRepository<Receipt>().AddAsync(receipt);

            await unitOfWork.SaveAsync();

            // Eğer hareket DTO'ları geldiyse, Movements listesine map et ve Receipt'e ata
            if (request.CreateMovementReceiptRequestDtos != null && request.CreateMovementReceiptRequestDtos.Any())
            {
                var movements = mapper.Map<Movements, CreateMovementReceiptRequestDto>(request.CreateMovementReceiptRequestDtos);
                foreach (var item in movements)
                {
                    item.ReceiptId = receipt.Id;
                    item.CreatedByUserId = 1;
                }
                receipt.Movements = movements;
            }

            // Gerekiyorsa ek alanları set et (örnek)
            receipt.CreatedByUserId = 1;

            await unitOfWork.GetWriteRepository<Movements>().AddRangeAsync(receipt.Movements);

            await unitOfWork.SaveAsync();

            await unitOfWork.CommitAsync();

            return new ResponseDto<CreateReceiptCommandResponse>().Success();
        }
    }
}
