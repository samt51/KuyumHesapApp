using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public int? ParentId { get; set; }
        public Menu? Parent { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; } = true;
        public string? RequeiredPermissionCode { get; set; }
        public List<Menu> Menus { get; set; } = new();
    }
}
