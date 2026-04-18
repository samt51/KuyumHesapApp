using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Command.Create
{
    public class CreatePageActionCommandRequest : IRequest<ResponseDto<CreatePageActionCommandResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string PageCode { get; set; } = string.Empty;
        public string? IconUrl { get; set; }
        public int OrderNo { get; set; }
        public string RequiredPermissionCode { get; set; } = string.Empty;
    }
}
