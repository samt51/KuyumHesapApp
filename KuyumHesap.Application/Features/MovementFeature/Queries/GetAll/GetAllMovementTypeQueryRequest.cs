using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Queries.GetAll
{
    public class GetAllMovementTypeQueryRequest : IRequest<ResponseDto<List<GetAllMovementTypeQueryResponse>>>
    {
    }
}
