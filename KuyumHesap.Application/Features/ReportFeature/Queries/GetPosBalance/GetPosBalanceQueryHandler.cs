using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetPosBalance
{
    public class GetPosBalanceQueryHandler : BaseHandler, IRequestHandler<GetPosBalanceQueryRequest, ResponseDto<GetPosBalanceQueryResponse>>
    {
        private readonly ITotalHasBalanceQuery _totalHasBalanceQuery;
        public GetPosBalanceQueryHandler(ITotalHasBalanceQuery totalHasBalanceQuery, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _totalHasBalanceQuery = totalHasBalanceQuery;
        }

        public async Task<ResponseDto<GetPosBalanceQueryResponse>> Handle(GetPosBalanceQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GetPosBalanceQueryResponse();

            var data = await _totalHasBalanceQuery.GetTotalHasAsync("POSLAR", cancellationToken);

            response.Result = data;

            return new ResponseDto<GetPosBalanceQueryResponse>().Success(response);
        }
    }
}
