using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Queries.GetAll
{
    public class GetAllExchangeQueryHandler : BaseHandler, IRequestHandler<GetAllExchangeQueryRequest, ResponseDto<List<GetAllExchangeQueryResponse>>>
    {
        public GetAllExchangeQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllExchangeQueryResponse>>> Handle(GetAllExchangeQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Currency>().GetAllAsync(x => !x.IsDeleted);

            var map = mapper.Map<GetAllExchangeQueryResponse, Currency>(data);

            return new ResponseDto<List<GetAllExchangeQueryResponse>>().Success(map);
        }
    }
}
