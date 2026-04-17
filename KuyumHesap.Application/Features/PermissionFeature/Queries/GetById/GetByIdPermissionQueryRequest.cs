using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PermissionFeature.Queries.GetById
{
    public class GetByIdPermissionQueryRequest : IRequest<ResponseDto<GetByIdPermissionQueryResponse>>
    {
        public int Id { get; set; }

        public GetByIdPermissionQueryRequest(int id)
        {
            Id = id;
        }
    }
}
