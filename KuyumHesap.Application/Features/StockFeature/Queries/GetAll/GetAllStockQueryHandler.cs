using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.StockFeature.Queries.GetAll
{
    public class GetAllStockQueryHandler : BaseHandler, IRequestHandler<GetAllStockQueryRequest, ResponseDto<List<GetAllStockQueryResponse>>>
    {
        public GetAllStockQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllStockQueryResponse>>> Handle(GetAllStockQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Stock>().GetAllAsync(x => !x.IsDeleted);
            var mappedData = mapper.Map<GetAllStockQueryResponse, Stock>(data);

            return new ResponseDto<List<GetAllStockQueryResponse>>().Success(mappedData);
        }
    }
}
