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

            var data = await _accountBalanceQuery.GetReportByAccountTypeNameAsync("BANKALAR", request.AccountId, cancellationToken);

            rsp.Detaylar = data.Details;
            rsp.ToplamBakiyeHas = data.TotalBalanceHas;

            return new ResponseDto<GetBankReportQueryResponse>().Success(rsp);
        }
    }
}
