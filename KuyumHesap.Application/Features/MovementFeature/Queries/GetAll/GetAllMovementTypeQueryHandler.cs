using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Queries.GetAll
{
    public class GetAllMovementTypeQueryHandler : BaseHandler, IRequestHandler<GetAllMovementTypeQueryRequest, ResponseDto<List<GetAllMovementTypeQueryResponse>>>
    {
        public GetAllMovementTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllMovementTypeQueryResponse>>> Handle(GetAllMovementTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<MovementType>().GetAllAsync(x => !x.IsDeleted && x.IsActive, orderBy: y => y.OrderBy(c => c.TransactionName));

            var map = mapper.Map<GetAllMovementTypeQueryResponse, MovementType>(data);

            return new ResponseDto<List<GetAllMovementTypeQueryResponse>>().Success(map);
        }

    }
}
