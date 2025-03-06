using Playstation.Domain.Entity;

namespace Playstation.Application.Models.Booking
{
    public  class BookingRM:BaseResponceModel
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public PlayStationRoom Room { get; set; }
        public Guid GameId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
    }
}
