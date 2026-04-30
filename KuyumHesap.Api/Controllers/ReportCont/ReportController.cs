using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetAccountStatement;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetBankReport;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetFilterReport;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetFilterTypes;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetPosReport;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetStockReport;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.ReportCont
{
    public class ReportController : BaseController
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("hesap-ekstresi/{hesapId}")]
        public async Task<ResponseDto<GetAccountStatementQueryResponse>> GetAccountStatementByAccountIdAsync(int hesapId, [FromQuery] DateTime startDate, [FromQuery] DateTime finishDate)
        {
            return await _mediator.Send(new GetAccountStatementQueryRequest
            {
                AccountId = hesapId,
                StartDate = startDate,
                FinishDate = finishDate
            });
        }
        
        [HttpPost]
        public async Task<ResponseDto<List<GetFilterReportQueryResponse>>> GetFilterReportAsync([FromBody]GetFilterReportQueryRequest request)
        {
            return await _mediator.Send(request);
        }
 
        [HttpGet]
        public async Task<ResponseDto<List<GetFilterTypesQueryResponse>>> GetFilterTypesAsync()
        {
            return await _mediator.Send(new GetFilterTypesQueryRequest());
        }
        [HttpGet]
        public async Task<ResponseDto<GetCashReportQueryResponse>> GetCashReportAsync()
        {
            return await _mediator.Send(new GetCashReportQueryRequest());
        }
        [HttpGet]
        public async Task<ResponseDto<GetPosReportQueryResponse>> GetPosReportAsync()
        {
            return await _mediator.Send(new GetPosReportQueryRequest());
        }
        [HttpGet]
        public async Task<ResponseDto<GetBankReportQueryResponse>> GetBankReportAsync()
        {
            return await _mediator.Send(new GetBankReportQueryRequest());
        }
        [HttpGet("{stockGroupAccountId}")]
        public async Task<ResponseDto<GetStockReportQueryResponse>> GetStockReportAsync(int stockGroupAccountId)
        {
            return await _mediator.Send(new GetStockReportQueryRequest(stockGroupAccountId));

        }
    }
}
