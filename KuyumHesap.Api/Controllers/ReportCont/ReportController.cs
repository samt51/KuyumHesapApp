using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetAccountStatement;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetAllReports;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetBankBalance;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetBankReport;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetCashReport;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetPosBalance;
using KuyumHesap.Application.Features.ReportFeature.Queries.GetPosReport;
using MediatR;
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
        [HttpGet]
        public async Task<ResponseDto<GetAllReportQueryResponse>> GetAllReportAsync(int? hesapId)
        {
            return await _mediator.Send(new GetAllReportQueryRequest(hesapId));
        }
        [HttpGet]
        public async Task<ResponseDto<CashReportModelResponseDto>> GetCashReportAsync(int? accountId)
        {
            return await _mediator.Send(new GetCashReportQueryRequest(accountId));
        }
        [HttpGet("bankalar-bakiye")]
        public async Task<ResponseDto<GetBankBalanceQueryResponse>> GetBankBalanceAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetBankBalanceQueryRequest(), token);
        }
        [HttpGet("poslar-bakiye")]
        public async Task<ResponseDto<GetPosBalanceQueryResponse>> GetPoslarBakiye(CancellationToken token)
        {
            return await _mediator.Send(new GetPosBalanceQueryRequest(), token);
        }
        [HttpGet("bankalar-raporu")]
        public async Task<ResponseDto<GetBankReportQueryResponse>> GetBankRaporu([FromQuery] int hesapId, CancellationToken token)
        {
            return await _mediator.Send(new GetBankReportQueryRequest(hesapId), token);
        }
        [HttpGet("poslar-raporu")]
        public async Task<ResponseDto<GetPosReportQueryResponse>> GetPoslarRaporu([FromQuery] int hesapId, CancellationToken token)
        {
            return await _mediator.Send(new GetPosReportQueryRequest(hesapId), token);
        }

    }
}
