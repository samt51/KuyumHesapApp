using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.TaskItemFeature.Queries.GetById
{
    public class GetByIdTaskItemQueryRequest : IRequest<ResponseDto<GetByIdTaskItemQueryResponse>>
    {
        public int Id { get; set; }
    }
}
