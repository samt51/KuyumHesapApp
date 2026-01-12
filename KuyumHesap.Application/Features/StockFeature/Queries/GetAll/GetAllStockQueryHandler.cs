using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.StockFeature.Queries.GetAll
{
    public class GetAllStockQueryHandler : BaseHandler, IRequestHandler<GetAllStockQueryRequest, ResponseDto<List<GetAllStockQueryResponse>>>
    {
        public GetAllStockQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllStockQueryResponse>>> Handle(GetAllStockQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork
         .GetReadRepository<Stock>()
         .GetAllAsync(
             x => !x.IsDeleted,
        include: q => q
        .Include(s => s.StockGroup)
        .Include(s => s.StockType).ThenInclude(st => st.Currency)
        .Include(s => s.StockType).ThenInclude(st => st.StockGroup));


            var mappedData = mapper.Map<List<GetAllStockQueryResponse>>(data);

            return new ResponseDto<List<GetAllStockQueryResponse>>().Success(mappedData);
        }
    }
}
