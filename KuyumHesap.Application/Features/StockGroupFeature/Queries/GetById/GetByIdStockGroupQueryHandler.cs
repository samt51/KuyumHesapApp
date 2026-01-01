using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using System.Net.WebSockets;

namespace KuyumHesap.Application.Features.StockGroupFeature.Queries.GetById
{
    public class GetByIdStockGroupQueryHandler : BaseHandler, IRequestHandler<GetByIdStockGroupQueryRequest, ResponseDto<GetByIdStockGroupQueryResponse>>
    {
        public GetByIdStockGroupQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdStockGroupQueryResponse>> Handle(GetByIdStockGroupQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<StockGroup>().GetAsync(x => !x.IsDeleted && x.Id == request.Id);

            var mapData = mapper.Map<GetByIdStockGroupQueryResponse, StockGroup>(data);

            return new ResponseDto<GetByIdStockGroupQueryResponse>().Success(mapData);
        }
    }
}
