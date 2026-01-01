using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetById
{
    public class GetByIdProductTypeQueryHandler : BaseHandler, IRequestHandler<GetByIdProductTypeQueryRequest, ResponseDto<GetByIdProductTypeQueryResponse>>
    {
        public GetByIdProductTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdProductTypeQueryResponse>> Handle(GetByIdProductTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<ProductType>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var mapData = mapper.Map<GetByIdProductTypeQueryResponse, ProductType>(data);

            return new ResponseDto<GetByIdProductTypeQueryResponse>().Success(mapData);
        }
    }
}
