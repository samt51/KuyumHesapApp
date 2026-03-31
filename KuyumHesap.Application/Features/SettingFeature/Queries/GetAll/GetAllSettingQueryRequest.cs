using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.SettingFeature.Queries.GetAll
{
    public class GetAllSettingQueryRequest : IRequest<ResponseDto<List<GetAllSettingQueryResponse>>>
    {
    }
}
