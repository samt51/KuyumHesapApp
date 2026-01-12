using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAllMyTask
{
    public class GetAllMyTaskQueryRequest : IRequest<ResponseDto<GetAllMyTaskQueryResponse>>
    {
    }
}
