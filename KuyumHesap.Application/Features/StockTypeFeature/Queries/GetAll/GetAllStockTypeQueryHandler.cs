using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.StockTypeFeature.Queries.GetAll
{
    public class GetAllStockTypeQueryHandler : BaseHandler, IRequestHandler<GetAllStockTypeQueryRequest, ResponseDto<List<GetAllStockTypeQueryResponse>>>
    {
        public GetAllStockTypeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllStockTypeQueryResponse>>> Handle(GetAllStockTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<StockType>().GetAllAsync(x => !x.IsDeleted,include:x=>x.Include(y=>y.StockGroup).Include(y=>y.Currency));

            var mappedData = mapper.Map<GetAllStockTypeQueryResponse, StockType>(data);

            return new ResponseDto<List<GetAllStockTypeQueryResponse>>().Success(mappedData);   
        }
    }
}
