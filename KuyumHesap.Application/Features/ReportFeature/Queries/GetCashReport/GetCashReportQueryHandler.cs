using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities.VwModels;
using MediatR;
using System;
using System.Threading;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport
{
    public class GetCashReportQueryHandler : BaseHandler, IRequestHandler<GetCashReportQueryRequest, ResponseDto<GetCashReportQueryResponse>>
    {
        private readonly IAccountBalanceQuery _accountBalanceQuery;
        public GetCashReportQueryHandler(IAccountBalanceQuery accountBalanceQuery, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _accountBalanceQuery = accountBalanceQuery;
        }

        public async Task<ResponseDto<GetCashReportQueryResponse>> Handle(GetCashReportQueryRequest request, CancellationToken cancellationToken)
        {
            var result = new GetCashReportQueryResponse();
           
            var data = await _accountBalanceQuery.GetAsync("KASALAR", request.AccountId, cancellationToken);

            result.ToplamBakiyeHas = Math.Abs(data.ToplamBakiyeHas);
            
            result.Detaylar = data.Detaylar;    

            return new ResponseDto<GetCashReportQueryResponse>().Success(result);
        }
    }
}
