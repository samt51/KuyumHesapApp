using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.MovementFeature.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetById
{
    public class GetByIdReceiptQueryHandler : BaseHandler, IRequestHandler<GetByIdReceiptQueryRequest, ResponseDto<GetByIdReceiptQueryResponse>>
    {
        public GetByIdReceiptQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdReceiptQueryResponse>> Handle(GetByIdReceiptQueryRequest request, CancellationToken cancellationToken)
        {
            // Include ile Receipt, Account, Account.AccountType ve Movements -> (Account, AccountType, TransactionType) yüklüyoruz
            var receipt = await unitOfWork.GetReadRepository<Receipt>().GetAsync(
                x => !x.IsDeleted && x.Id == request.Id,
                include: q => q
                    .Include(r => r.Account)
                        .ThenInclude(a => a.AccountType)
                    .Include(r => r.Movements)
                        .ThenInclude(m => m.Account)
                            .ThenInclude(a => a.AccountType)
                    .Include(r => r.Movements)
                        .ThenInclude(m => m.TransactionType)
            );

            if (receipt == null)
                return new ResponseDto<GetByIdReceiptQueryResponse>().Success(null);

            // Receipt -> GetByIdReceiptQueryResponse map (AutoMapper mapping'leri kullanılır)
            var mapReceipt = mapper.Map<GetByIdReceiptQueryResponse, Receipt>(receipt);

            // Garantili olarak Movements map'ini sağlamak için, eğer mapper otomatik atamadıysa elle map et
            if ((mapReceipt.Movements == null || !mapReceipt.Movements.Any()) && receipt.Movements != null)
            {
                mapReceipt.Movements = mapper.Map<GetMovementByCustomerIdResponse, Movements>(receipt.Movements);
            }

            return new ResponseDto<GetByIdReceiptQueryResponse>().Success(mapReceipt);
        }
    }
}