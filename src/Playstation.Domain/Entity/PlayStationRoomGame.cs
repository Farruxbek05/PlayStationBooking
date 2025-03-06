using Playstation.Domain.Common;

namespace Playstation.Domain.Entity;

public class PlayStationRoomGame : BaseEntity, IAuditedEntity
{
    public Guid PlayStationRoomId { get; set; }
    public required PlayStationRoom PlayStationRoom { get; set; }
    public Guid GameId { get; set; }
    public Game Game { get; set; }
    public decimal PricePerHour { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}

