using Playstation.Domain.Common;

namespace Playstation.Domain.Entity
{
    public class Booking : BaseEntity, IAuditedEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid RoomId { get; set; }
        public PlayStationRoom Room { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }


    public enum BookingStatus
    {
        Pending,
        Completed,
        Canceled
    }

}
