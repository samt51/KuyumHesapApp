using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetProductType
{
    public class GetProductTypeQueryHandler : BaseHandler, IRequestHandler<GetProductTypeQueryRequest, ResponseDto<List<GetProductTypeQueryResponse>>>
    {
        public GetProductTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetProductTypeQueryResponse>>> Handle(GetProductTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<ProductType>().GetAllAsync(x => !x.IsDeleted, orderBy: y => y.OrderBy(x => x.ProductTypeName));

            var map = mapper.Map<GetProductTypeQueryResponse, ProductType>(data);

            return new ResponseDto<List<GetProductTypeQueryResponse>>().Success(map);
        }
    }
}
