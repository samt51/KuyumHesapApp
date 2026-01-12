using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Queries.GetById
{
    public class GetByIdUserQueryRequest : IRequest<ResponseDto<GetByIdUserQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdUserQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
