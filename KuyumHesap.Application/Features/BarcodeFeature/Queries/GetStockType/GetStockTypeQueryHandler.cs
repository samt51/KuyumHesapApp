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
            var rsp = new List<GetStockTypeQueryResponse>();

            var data = await unitOfWork.GetReadRepository<StockType>().GetAllAsync(x => !x.IsDeleted && x.StockGroupId == request.StockGroupId, orderBy: c => c.OrderBy(y => y.StockTypeName));

            var map = mapper.Map<GetStockTypeQueryResponse, StockType>(data);

            return new ResponseDto<List<GetStockTypeQueryResponse>>().Success(map);
        }
    }
}
