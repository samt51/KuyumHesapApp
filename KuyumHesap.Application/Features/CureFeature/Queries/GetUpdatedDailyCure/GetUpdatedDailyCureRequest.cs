using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.CureFeature.Queries.GetUpdatedDailyCure
{
    public class GetUpdatedDailyCureRequest : IRequest<ResponseDto<GetUpdatedDailyCureResponse>>
    {
    }
}
