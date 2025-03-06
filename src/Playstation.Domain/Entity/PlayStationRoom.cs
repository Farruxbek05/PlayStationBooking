using Playstation.Domain.Common;

namespace Playstation.Domain.Entity
{
    public class PlayStationRoom : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid LocationId { get; set; }
        public Location Location { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public enum ConsoleStatus
    {
        Available,
        Busy,
        Maintenance
    }

}
