using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetBankBalance
{
    public class GetBankBalanceQueryHandler : BaseHandler, IRequestHandler<GetBankBalanceQueryRequest, ResponseDto<GetBankBalanceQueryResponse>>
    {
        private readonly ITotalHasBalanceQuery _totalHasBalanceQuery;
        public GetBankBalanceQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, ITotalHasBalanceQuery totalHasBalanceQuery) : base(mapper, unitOfWork)
        {
            _totalHasBalanceQuery = totalHasBalanceQuery;
        }

        public async Task<ResponseDto<GetBankBalanceQueryResponse>> Handle(GetBankBalanceQueryRequest request, CancellationToken cancellationToken)
        {
            var rsp = new GetBankBalanceQueryResponse();
            var data = await _totalHasBalanceQuery.GetTotalHasAsync("BANKALAR", cancellationToken);

            rsp.Result = data;

            return new ResponseDto<GetBankBalanceQueryResponse>().Success(rsp);
        }
    }
}
