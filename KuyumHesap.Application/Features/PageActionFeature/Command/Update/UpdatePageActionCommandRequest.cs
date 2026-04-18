using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.PageActionFeature.Command.Update
{
    public class UpdatePageActionCommandRequest : IRequest<ResponseDto<UpdatePageActionCommandResponse>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string PageCode { get; set; } = string.Empty;
        public string? IconUrl { get; set; }
        public int OrderNo { get; set; }
        public string RequiredPermissionCode { get; set; } = string.Empty;
    }
}
