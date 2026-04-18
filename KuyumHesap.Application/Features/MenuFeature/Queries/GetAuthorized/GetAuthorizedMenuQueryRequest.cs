using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Queries.GetAuthorized
{
    public class GetAuthorizedMenuQueryRequest : IRequest<ResponseDto<List<GetAuthorizedMenuQueryResponse>>>
    {
        public int UserId { get; set; }

        public GetAuthorizedMenuQueryRequest(int userId)
        {
            UserId = userId;
        }
    }
}
