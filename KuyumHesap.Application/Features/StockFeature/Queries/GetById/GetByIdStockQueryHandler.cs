using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.StockFeature.Queries.GetById
{
    public class GetByIdStockQueryHandler : BaseHandler, IRequestHandler<GetByIdStockQueryRequest, ResponseDto<GetByIdStockQueryResponse>>
    {
        public GetByIdStockQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdStockQueryResponse>> Handle(GetByIdStockQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Stock>().GetAsync(x => !x.IsDeleted && x.Id == request.Id, include: q => q
                 .Include(s => s.StockGroup)
                 .Include(s => s.StockType).ThenInclude(st => st.Currency)
                 .Include(s => s.StockType).ThenInclude(st => st.StockGroup));

            var mapData = mapper.Map<GetByIdStockQueryResponse, Stock>(data);

            return new ResponseDto<GetByIdStockQueryResponse>().Success(mapData);
        }
    }
}
