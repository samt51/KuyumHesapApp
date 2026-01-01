using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetAll
{
    public class GetAllProductTypeQueryHandler : BaseHandler, IRequestHandler<GetAllProductTypeQueryRequest, ResponseDto<List<GetAllProductTypeQueryResponse>>>
    {
        public GetAllProductTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllProductTypeQueryResponse>>> Handle(GetAllProductTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<ProductType>().GetAllAsync(x => !x.IsDeleted);

            var mapData = mapper.Map<GetAllProductTypeQueryResponse, ProductType>(data);

            return new ResponseDto<List<GetAllProductTypeQueryResponse>>().Success(mapData);
        }
    }
}
