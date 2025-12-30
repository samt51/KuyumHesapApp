using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock
{
    public class GetStockGroupQueryHandler : BaseHandler, IRequestHandler<GetStockGroupQueryRequest, ResponseDto<List<GetStockGroupQueryResponse>>>
    {
        public GetStockGroupQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetStockGroupQueryResponse>>> Handle(GetStockGroupQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<StockGroup>().GetAllAsync(orderBy: x => x.OrderBy(y => y.StockGroupName));

            var map = mapper.Map<GetStockGroupQueryResponse, StockGroup>(data);

            return new ResponseDto<List<GetStockGroupQueryResponse>>().Success(map);
        }
    }
}
