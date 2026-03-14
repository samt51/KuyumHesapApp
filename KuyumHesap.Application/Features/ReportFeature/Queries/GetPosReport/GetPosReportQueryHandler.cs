using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetPosReport
{
    public class GetPosReportQueryHandler : BaseHandler, IRequestHandler<GetPosReportQueryRequest, ResponseDto<GetPosReportQueryResponse>>
    {
        private readonly IAccountBalanceQuery _accountBalanceQuery;
        public GetPosReportQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAccountBalanceQuery accountBalanceQuery) : base(mapper, unitOfWork)
        {
            _accountBalanceQuery = accountBalanceQuery;
        }

        public async Task<ResponseDto<GetPosReportQueryResponse>> Handle(GetPosReportQueryRequest request, CancellationToken cancellationToken)
        {
            var rsp = new GetPosReportQueryResponse();

            var data = await _accountBalanceQuery.GetReportByAccountTypeNameAsync("POSLAR", request.AccountId, cancellationToken);

            rsp.Detaylar = data.Details;
            rsp.ToplamBakiyeHas = data.TotalBalanceHas;

            return new ResponseDto<GetPosReportQueryResponse>().Success(rsp);
        }
    }
}
