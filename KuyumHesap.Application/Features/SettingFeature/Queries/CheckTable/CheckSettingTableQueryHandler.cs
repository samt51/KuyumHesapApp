using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.SettingFeature.Queries.CheckTable
{
    public class CheckSettingTableQueryHandler : BaseHandler, IRequestHandler<CheckSettingTableQueryRequest, ResponseDto<CheckSettingTableQueryResponse>>
    {


        public CheckSettingTableQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CheckSettingTableQueryResponse>> Handle(CheckSettingTableQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CheckSettingTableQueryResponse();

            try
            {
                response.TableCreated = true;
                response.Message = "result.message;";
            }
            catch (Exception ex)
            {
                return new ResponseDto<CheckSettingTableQueryResponse>().Fail("Tablo kontrolü sırasında hata: " + ex.Message);
            }

            return new ResponseDto<CheckSettingTableQueryResponse>().Success(response);
        }
    }
}
