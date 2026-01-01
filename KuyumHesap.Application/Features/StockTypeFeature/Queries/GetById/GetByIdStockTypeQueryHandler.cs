using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.StockTypeFeature.Queries.GetById
{
    public class GetByIdStockTypeQueryHandler : BaseHandler, IRequestHandler<GetByIdStockTypeQueryRequest, ResponseDto<GetByIdStockTypeQueryResponse>>
    {
        public GetByIdStockTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdStockTypeQueryResponse>> Handle(GetByIdStockTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<StockType>().GetAsync(x => !x.IsDeleted && x.Id == request.Id, include: y => y.Include(x => x.Currency).Include(y => y.StockGroup));

            var map = mapper.Map<GetByIdStockTypeQueryResponse, StockType>(data);

            return new ResponseDto<GetByIdStockTypeQueryResponse>().Success(map);
        }
    }
}
