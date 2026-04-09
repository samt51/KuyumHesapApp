using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetById
{
    public class GetByIdRolesQueryRequest : IRequest<ResponseDto<GetByIdRolesQueryResponse>>
    {
        public int Id { get; set; }
        public GetByIdRolesQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}
