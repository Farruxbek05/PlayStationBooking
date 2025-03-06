using Playstation.Domain.Common;

namespace Playstation.Domain.Entity
{
    public class BookingSnack : BaseEntity, IAuditedEntity
    {
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }
        public Guid SnackId { get; set; }
        public Snack Snack { get; set; }
        public int Quantity { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

}
