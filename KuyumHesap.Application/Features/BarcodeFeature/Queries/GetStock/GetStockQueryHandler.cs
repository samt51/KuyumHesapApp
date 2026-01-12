using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock
{
    public class GetStockQueryHandler : BaseHandler, IRequestHandler<GetStockQueryRequest, ResponseDto<List<GetStockQueryResponse>>>
    {
        public GetStockQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetStockQueryResponse>>> Handle(GetStockQueryRequest request, CancellationToken cancellationToken)
        {

            var groupIds = request.StockTypeId.Distinct().ToList();

            var data = await unitOfWork.GetReadRepository<Stock>().GetAllAsync(x => groupIds.Contains(x.StockTypeId) && !x.IsDeleted);

            var map = mapper.Map<GetStockQueryResponse, Stock>(data);

            return new ResponseDto<List<GetStockQueryResponse>>().Success(map);


        }
    }
}
