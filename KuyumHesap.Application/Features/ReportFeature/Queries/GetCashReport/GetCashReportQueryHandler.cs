using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport
{
    public class GetCashReportQueryHandler : BaseHandler, IRequestHandler<GetCashReportQueryRequest, ResponseDto<CashReportModelResponseDto>>
    {
        private readonly IAccountBalanceQuery _accountBalanceQuery;
        public GetCashReportQueryHandler(IAccountBalanceQuery accountBalanceQuery, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _accountBalanceQuery = accountBalanceQuery;
        }

        public async Task<ResponseDto<CashReportModelResponseDto>> Handle(GetCashReportQueryRequest request, CancellationToken cancellationToken)
        {
            var result = new GetCashReportQueryResponse();
            var data = await _accountBalanceQuery.GetReportByAccountTypeNameAsync("KASALAR", request.AccountId, cancellationToken);
            return new ResponseDto<CashReportModelResponseDto>().Success(data);
        }
    }
}
