using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetAllReports
{
    public class GetAllReportQueryHandler : BaseHandler, IRequestHandler<GetAllReportQueryRequest, ResponseDto<GetAllReportQueryResponse>>
    {
        private readonly IAccountBalanceQuery _accountBalanceQuery;
        private readonly ITotalHasBalanceQuery _totalHasBalanceQuery;
        public GetAllReportQueryHandler(ITotalHasBalanceQuery totalHasBalanceQuery, IAccountBalanceQuery accountBalanceQuery, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _accountBalanceQuery = accountBalanceQuery;
            _totalHasBalanceQuery = totalHasBalanceQuery;
        }

        public async Task<ResponseDto<GetAllReportQueryResponse>> Handle(GetAllReportQueryRequest request, CancellationToken cancellationToken)
        {
            var result = new GetAllReportQueryResponse();

            var data = await _accountBalanceQuery.GetAsync("KASALAR", request.AccountId, cancellationToken);

            var bankBalance = await _totalHasBalanceQuery.GetTotalHasAsync("BANKALAR", cancellationToken);

            var posBalance = await _totalHasBalanceQuery.GetTotalHasAsync("POSLAR", cancellationToken);

            result.ToplamBakiyeHas = Math.Abs(data.ToplamBakiyeHas);

            result.Detaylar = data.Detaylar;

            result.BankBalanceTotal = bankBalance;

            result.PosBalanceTotal = posBalance;

            return new ResponseDto<GetAllReportQueryResponse>().Success(result);

        }
    }
}
