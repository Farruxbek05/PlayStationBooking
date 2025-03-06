using Playstation.Domain.Common;

namespace Playstation.Domain.Entity
{
    public class Location : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
