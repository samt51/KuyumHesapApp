using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.MovementFeature.Queries.GetMovementByReceiptId
{
    public class GetMovementByReceiptIdHandler : BaseHandler, IRequestHandler<GetMovementByReceiptIdRequest, ResponseDto<List<GetMovementByReceiptIdResponse>>>
    {
        public GetMovementByReceiptIdHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetMovementByReceiptIdResponse>>> Handle(GetMovementByReceiptIdRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Movements>().GetAllAsync(
                          x => !x.IsDeleted && x.ReceiptId == request.ReceiptId,
                          include: y => y.Include(y => y.Receipt)
                                        .ThenInclude(c => c.Account)
                                        .Include(y => y.Account)
                                        .ThenInclude(y => y.AccountType),
                          enableTracking: false,
                          ct: cancellationToken);


            var mapped = mapper.Map<GetMovementByReceiptIdResponse, Movements>(data);

            return new ResponseDto<List<GetMovementByReceiptIdResponse>>().Success(mapped);
        }
    }
}
