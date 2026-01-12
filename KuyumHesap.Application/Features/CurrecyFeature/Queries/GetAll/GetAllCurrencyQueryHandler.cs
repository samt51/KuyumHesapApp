using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.CurrecyFeature.Queries.GetAll
{
    public class GetAllCurrencyQueryHandler : BaseHandler, IRequestHandler<GetAllCurrencyQueryRequest, ResponseDto<List<GetAllCurrencyQueryResponse>>>
    {
        public GetAllCurrencyQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllCurrencyQueryResponse>>> Handle(GetAllCurrencyQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Currency>().GetAllAsync(x => !x.IsDeleted);

            var map = mapper.Map<GetAllCurrencyQueryResponse, Currency>(data);

            return new ResponseDto<List<GetAllCurrencyQueryResponse>>().Success(map);
        }
    }
}
