using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Queries.GetExchangeRateByCurrencyCode
{
    public class GetExchangeRateByCurrencyCodeHandler : BaseHandler, IRequestHandler<GetExchangeRateByCurrencyCodeRequest, ResponseDto<GetExchangeRateByCurrencyCodeResponse>>
    {
        public GetExchangeRateByCurrencyCodeHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetExchangeRateByCurrencyCodeResponse>> Handle(GetExchangeRateByCurrencyCodeRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<ExchangeRate>().GetAsync(x => x.CurrencyId == request.CurrencyId,
                orderBy: y => y.OrderByDescending(c => c.CreatedDate));

            var rst = new GetExchangeRateByCurrencyCodeResponse { Result = data?.BuyRate ?? 0 };
            return new ResponseDto<GetExchangeRateByCurrencyCodeResponse>().Success(rst);
        }
    }
}
