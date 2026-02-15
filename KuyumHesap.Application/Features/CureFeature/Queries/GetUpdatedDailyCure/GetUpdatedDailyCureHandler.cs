using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Aut;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.CureFeature.Queries.GetUpdatedDailyCure
{
    public class GetUpdatedDailyCureHandler : BaseHandler, IRequestHandler<GetUpdatedDailyCureRequest, ResponseDto<GetUpdatedDailyCureResponse>>
    {
        private readonly IKurGuncellemeService _kurGuncellemeService;
        public GetUpdatedDailyCureHandler(IKurGuncellemeService kurGuncellemeService, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _kurGuncellemeService = kurGuncellemeService;
        }

        public async Task<ResponseDto<GetUpdatedDailyCureResponse>> Handle(GetUpdatedDailyCureRequest request, CancellationToken cancellationToken)
        {
            var data = await _kurGuncellemeService.GetDailyCureData();

            var mapData = mapper.Map<GetUpdatedDailyCureResponse, DailyCureDataDto.Data>(data);

            return new ResponseDto<GetUpdatedDailyCureResponse>().Success(mapData);
        }
    }
}
