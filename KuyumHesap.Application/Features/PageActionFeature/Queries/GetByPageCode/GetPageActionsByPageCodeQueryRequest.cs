using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Queries.GetByPageCode
{
    public class GetPageActionsByPageCodeQueryRequest : IRequest<ResponseDto<List<GetPageActionsByPageCodeQueryResponse>>>
    {
        public string PageCode { get; set; }

        public GetPageActionsByPageCodeQueryRequest(string pageCode)
        {
            PageCode = pageCode;
        }
    }
}
