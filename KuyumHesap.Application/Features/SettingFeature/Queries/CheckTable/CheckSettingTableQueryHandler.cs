using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;

namespace KuyumHesap.Application.Features.SettingFeature.Queries.CheckTable
{
    public class CheckSettingTableQueryHandler : BaseHandler, IRequestHandler<CheckSettingTableQueryRequest, ResponseDto<CheckSettingTableQueryResponse>>
    {
        private readonly ISettingTableCheckService _tableCheckService;

        public CheckSettingTableQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, ISettingTableCheckService tableCheckService) : base(mapper, unitOfWork)
        {
            _tableCheckService = tableCheckService;
        }

        public async Task<ResponseDto<CheckSettingTableQueryResponse>> Handle(CheckSettingTableQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CheckSettingTableQueryResponse();
            
            try 
            {
                var result = await _tableCheckService.EnsureSettingsTableExistsAsync(cancellationToken);
                response.TableCreated = result.tableCreated;
                response.Message = result.message;
            }
            catch (Exception ex)
            {
                return new ResponseDto<CheckSettingTableQueryResponse>().Fail("Tablo kontrolü sırasında hata: " + ex.Message);
            }
            
            return new ResponseDto<CheckSettingTableQueryResponse>().Success(response);
        }
    }
}
