using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetBankReport
{
    public class GetBankReportQueryHandler : BaseHandler, IRequestHandler<GetBankReportQueryRequest, ResponseDto<GetBankReportQueryResponse>>
    {
        private readonly IAccountBalanceQuery _accountBalanceQuery;
        public GetBankReportQueryHandler(IAccountBalanceQuery accountBalanceQuery, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _accountBalanceQuery = accountBalanceQuery;
        }

        public async Task<ResponseDto<GetBankReportQueryResponse>> Handle(GetBankReportQueryRequest request, CancellationToken cancellationToken)
        {
            var rsp = new GetBankReportQueryResponse();

            var data = await _accountBalanceQuery.GetAsync("BANKALAR", request.AccountId, cancellationToken);

            rsp.Detaylar = data.Detaylar;
            rsp.ToplamBakiyeHas = data.ToplamBakiyeHas;

            return new ResponseDto<GetBankReportQueryResponse>().Success(rsp);
        }
    }
}
