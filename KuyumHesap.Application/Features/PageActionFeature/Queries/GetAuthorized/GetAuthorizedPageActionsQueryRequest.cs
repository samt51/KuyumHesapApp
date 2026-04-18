using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Queries.GetAuthorized
{
    public class GetAuthorizedPageActionsQueryRequest : IRequest<ResponseDto<List<GetAuthorizedPageActionsQueryResponse>>>
    {
        public int UserId { get; set; }
        public string PageCode { get; set; }

        public GetAuthorizedPageActionsQueryRequest(int userId, string pageCode)
        {
            UserId = userId;
            PageCode = pageCode;
        }
    }
}
