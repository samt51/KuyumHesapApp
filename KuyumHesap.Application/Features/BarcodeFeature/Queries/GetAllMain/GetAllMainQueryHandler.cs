using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetPacker;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetProductType;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockType;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.BarcodeFeature.Queries.GetAllMain
{
    public class GetAllMainQueryHandler : BaseHandler, IRequestHandler<GetAllMainQueryRequest, ResponseDto<GetAllMainQueryResponse>>
    {
        public GetAllMainQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetAllMainQueryResponse>> Handle(GetAllMainQueryRequest request, CancellationToken cancellationToken)
        {
            var rsp = new GetAllMainQueryResponse();

            var data = await unitOfWork.GetReadRepository<StockGroup>().GetAllAsync(orderBy: x => x.OrderBy(y => y.StockGroupName));

            var map = mapper.Map<GetStockGroupQueryResponse, StockGroup>(data);


            var groupIds = map.Select(x => x.Id).Distinct().ToList();

            var stockTypes = await unitOfWork
                .GetReadRepository<StockType>()
                .GetAllAsync(
                    x => !x.IsDeleted && groupIds.Contains(x.StockGroupId),
                    orderBy: q => q.OrderBy(y => y.StockTypeName)
                );
            var getStockTypeQueryResponses = mapper.Map<GetStockTypeQueryResponse,StockType>(stockTypes);

            var stockTypeIds = getStockTypeQueryResponses.Select(x => x.Id).Distinct().ToList();

            var stockType = await unitOfWork.GetReadRepository<Stock>().GetAllAsync(x => stockTypeIds.Contains(x.StockTypeId) && !x.IsDeleted);

            var stockTypemap = mapper.Map<GetStockQueryResponse, Stock>(stockType);

            var productTypesData = await unitOfWork.GetReadRepository<ProductType>().GetAllAsync(x => !x.IsDeleted, orderBy: y => y.OrderBy(x => x.ProductTypeName));

            var productTypesMap = mapper.Map<GetProductTypeQueryResponse, ProductType>(productTypesData);

            rsp.getStockGroupQueries = map;
            rsp.getStockTypeQueries = getStockTypeQueryResponses;
            rsp.getStockQueries = stockTypemap;
            rsp.getProductTypeQueries = productTypesMap;


            var accountData = await unitOfWork.GetReadRepository<Account>().GetAllAsync(x => !x.IsDeleted, orderBy: y => y.OrderBy(c => c.AccountName));

            var accountMap = mapper.Map<GetPackerQueryResponse, Account>(accountData);

            rsp.getPackerQueryResponses = accountMap;

            return new ResponseDto<GetAllMainQueryResponse>().Success(rsp);

        }
    }
}
