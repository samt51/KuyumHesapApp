using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using KuyumHesap.Domain.Entities.VwModels;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetById
{
    public class GetByIdReceiptQueryHandler : BaseHandler, IRequestHandler<GetByIdReceiptQueryRequest, ResponseDto<GetByIdReceiptQueryResponse>>
    {
        public GetByIdReceiptQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdReceiptQueryResponse>> Handle(GetByIdReceiptQueryRequest request, CancellationToken cancellationToken)
        {
            var receipt = await unitOfWork.GetReadRepository<Receipt>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var mapReceipt = mapper.Map<GetByIdReceiptQueryResponse, Receipt>(receipt);
            mapReceipt.AccountId = receipt.AccountId;

            var movements = await unitOfWork.GetReadRepository<Movements>().GetAllAsync(x => !x.IsDeleted && x.ReceiptId == request.Id);

            mapReceipt.Movements = movements.ToList();

            return new ResponseDto<GetByIdReceiptQueryResponse>().Success(mapReceipt);
        }
    }
}
