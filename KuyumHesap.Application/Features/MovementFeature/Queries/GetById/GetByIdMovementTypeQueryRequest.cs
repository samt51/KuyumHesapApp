using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MovementFeature.Queries.GetById
{
    public class GetByIdMovementTypeQueryRequest : IRequest<ResponseDto<GetByIdMovementTypeQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdMovementTypeQueryRequest(int id )
        {
                this.Id = id;   
        }
    }
}
