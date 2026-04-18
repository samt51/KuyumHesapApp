using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Queries.CheckAuthorized
{
    public class CheckAuthorizedPageActionQueryRequest : IRequest<ResponseDto<CheckAuthorizedPageActionQueryResponse>>
    {
        public int UserId { get; set; }
        public string PageCode { get; set; }
        public string ActionCode { get; set; }

        public CheckAuthorizedPageActionQueryRequest(int userId, string pageCode, string actionCode)
        {
            UserId = userId;
            PageCode = pageCode;
            ActionCode = actionCode;
        }
    }
}
