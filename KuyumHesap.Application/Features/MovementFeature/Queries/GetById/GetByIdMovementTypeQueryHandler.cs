using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Queries.GetById
{
    public class GetByIdMovementTypeQueryHandler : BaseHandler, IRequestHandler<GetByIdMovementTypeQueryRequest, ResponseDto<GetByIdMovementTypeQueryResponse>>
    {
        public GetByIdMovementTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdMovementTypeQueryResponse>> Handle(GetByIdMovementTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<MovementType>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var map = mapper.Map<GetByIdMovementTypeQueryResponse, MovementType>(data);

            return new ResponseDto<GetByIdMovementTypeQueryResponse>().Success(map);
        }
    }
}
