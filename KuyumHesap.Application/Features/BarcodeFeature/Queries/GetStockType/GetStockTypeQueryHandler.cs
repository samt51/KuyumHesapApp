using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockType
{
    public class GetStockTypeQueryHandler : BaseHandler, IRequestHandler<GetStockTypeQueryRequest, ResponseDto<List<GetStockTypeQueryResponse>>>
    {
        public GetStockTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetStockTypeQueryResponse>>> Handle(GetStockTypeQueryRequest request, CancellationToken cancellationToken)
        {
             
            if (request.StockGroupId == null || request.StockGroupId.Count == 0)
                return new ResponseDto<List<GetStockTypeQueryResponse>>()
                    .Success(new List<GetStockTypeQueryResponse>());

        
            var groupIds = request.StockGroupId.Distinct().ToList();

             
            var data = await unitOfWork
                .GetReadRepository<StockType>()
                .GetAllAsync(
                    x => !x.IsDeleted && groupIds.Contains(x.StockGroupId),
                    orderBy: q => q.OrderBy(y => y.StockTypeName)
                );

            
            var map = mapper.Map<List<GetStockTypeQueryResponse>>(data);

            return new ResponseDto<List<GetStockTypeQueryResponse>>().Success(map);
        }
    }
}
