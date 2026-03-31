using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.SettingFeature.Queries.GetAll
{
    public class GetAllSettingQueryHandler : BaseHandler, IRequestHandler<GetAllSettingQueryRequest, ResponseDto<List<GetAllSettingQueryResponse>>>
    {
        public GetAllSettingQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllSettingQueryResponse>>> Handle(GetAllSettingQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Setting>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<GetAllSettingQueryResponse, Setting>(data);
            return new ResponseDto<List<GetAllSettingQueryResponse>>().Success(map);
        }
    }
}
