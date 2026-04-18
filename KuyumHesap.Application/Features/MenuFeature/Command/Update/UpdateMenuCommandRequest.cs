using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Command.Update
{
    public class UpdateMenuCommandRequest : IRequest<ResponseDto<UpdateMenuCommandResponse>>
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public int OrderNo { get; set; }
        public bool IsActive { get; set; } = true;
        public string? RequeiredPermissionCode { get; set; }
    }
}
