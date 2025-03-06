using Playstation.Domain.Common;

namespace Playstation.Domain.Entity
{
    public class Review : BaseEntity, IAuditedEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
        public int Rating { get; set; } 
        public string? Comment { get; set; }
        public decimal AverageRating { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

}
