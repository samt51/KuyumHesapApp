using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.StockFeature.Queries.GetAll;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.StockFeature.Queries.GetByGroupId
{
    public class GetStockByGroupIdQueryHandler : BaseHandler, IRequestHandler<GetStockByGroupIdQueryRequest, ResponseDto<List<GetAllStockQueryResponse>>>
    {
        public GetStockByGroupIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllStockQueryResponse>>> Handle(GetStockByGroupIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork
                .GetReadRepository<Stock>()
                .GetAllAsync(
                    x => !x.IsDeleted && x.StockGroupId == request.GroupId,
                    include: q => q
                        .Include(s => s.StockGroup)
                        .Include(s => s.StockType)
                            .ThenInclude(st => st.Currency)
                );

            var mappedData = mapper.Map<List<GetAllStockQueryResponse>>(data);
            return new ResponseDto<List<GetAllStockQueryResponse>>().Success(mappedData);
        }
    }
}
