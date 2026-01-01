using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockGroupFeature.Queries.GetAll
{
    public class GetAllStockGroupQueryHandler : BaseHandler, IRequestHandler<GetAllStockGroupQueryRequest, ResponseDto<List<GetAllStockGroupQueryResponse>>>
    {
        public GetAllStockGroupQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllStockGroupQueryResponse>>> Handle(GetAllStockGroupQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<StockGroup>().GetAllAsync(x => !x.IsDeleted);

            var mapData = mapper.Map<GetAllStockGroupQueryResponse, StockGroup>(data);

            return new ResponseDto<List<GetAllStockGroupQueryResponse>>().Success(mapData);
        }
    }
}
