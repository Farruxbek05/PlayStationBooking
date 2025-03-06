using Playstation.Domain.Common;

namespace Playstation.Domain.Entity
{
    public class Payment : BaseEntity, IAuditedEntity
    {
        public Guid? BookingId { get; set; }
        public Booking? Booking { get; set; }
        public Guid? BookingSnackId { get; set; }
        public BookingSnack? BookingSnack { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public PaymentMethod PaymentMethod { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public enum PaymentMethod
    {
        Cash,
        Card
    }

}
