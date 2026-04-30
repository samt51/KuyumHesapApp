using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetFilterTypes
{
    public class GetFilterTypesQueryHandler : BaseHandler, IRequestHandler<GetFilterTypesQueryRequest, ResponseDto<List<GetFilterTypesQueryResponse>>>
    {
        public GetFilterTypesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetFilterTypesQueryResponse>>> Handle(GetFilterTypesQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new List<GetFilterTypesQueryResponse>{ new GetFilterTypesQueryResponse { FilterEnum =Dtos.Enums.FilterEnum.FinancialSummary,TypeId = 7,TypeName= "KASALAR"},
            new GetFilterTypesQueryResponse {FilterEnum = Dtos.Enums.FilterEnum.FinancialSummary,TypeId = 6,TypeName="POSLAR"},
            new GetFilterTypesQueryResponse {FilterEnum = Dtos.Enums.FilterEnum.FinancialSummary,TypeId = 5,TypeName="BANKALAR"},
            new GetFilterTypesQueryResponse {FilterEnum = Dtos.Enums.FilterEnum.StockSummary,TypeId = 1,TypeName="MAMUL"},
            new GetFilterTypesQueryResponse {FilterEnum = Dtos.Enums.FilterEnum.StockSummary,TypeId = 2,TypeName="MADEN"},
            new GetFilterTypesQueryResponse {FilterEnum = Dtos.Enums.FilterEnum.StockSummary,TypeId = 3,TypeName="HURDA"}};

            return new ResponseDto<List<GetFilterTypesQueryResponse>>().Success(response);
        }
    }
}
