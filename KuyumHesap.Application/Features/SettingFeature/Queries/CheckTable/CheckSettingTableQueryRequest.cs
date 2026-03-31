using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.SettingFeature.Queries.CheckTable
{
    public class CheckSettingTableQueryRequest : IRequest<ResponseDto<CheckSettingTableQueryResponse>>
    {
    }
}
