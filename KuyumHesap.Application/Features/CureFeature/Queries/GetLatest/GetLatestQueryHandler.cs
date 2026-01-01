using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.CureFeature.Queries.GetLatest
{
    public class GetLatestQueryHandler : BaseHandler, IRequestHandler<GetLatestQueryRequest, ResponseDto<List<GetLatestQueryResponse>>>
    {
        public GetLatestQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
        public async Task<ResponseDto<List<GetLatestQueryResponse>>> Handle(GetLatestQueryRequest request, CancellationToken cancellationToken)
        {
            var today = DateTime.Today;

            var currencies = await unitOfWork.GetReadRepository<Currency>().GetAllAsync(x => !x.IsDeleted);
            var rates = await unitOfWork.GetReadRepository<ExchangeRate>().GetAllAsync(x => !x.IsDeleted);

            var list = (
                from k in rates
                join d in currencies on k.ExchangeRateId equals d.Id
                where k.RateDate == today
                      && d.CurrencyCode != "TRY"
                orderby d.Id
                select new GetLatestQueryResponse
                {
                    CurrencyCode = d.CurrencyCode,
                    BuyRate = k.BuyRate,
                    SellRate = k.SellRate
                }
                ).ToList();

            return new ResponseDto<List<GetLatestQueryResponse>>().Success(list);
        }
    }
}
