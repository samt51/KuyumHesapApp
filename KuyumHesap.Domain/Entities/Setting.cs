using KuyumHesap.Domain.Command;

namespace KuyumHesap.Domain.Entities
{
    public class Setting : BaseEntity
    {
        public string Key { get; set; } = string.Empty;
        public string? Value { get; set; }
        public string? Description { get; set; }
    }
}
