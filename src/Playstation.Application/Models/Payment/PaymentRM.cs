using Playstation.Domain.Entity;

namespace Playstation.Application.Models.Payment
{
    public class PaymentRM:BaseResponceModel
    {
        public Guid? BookingId { get; set; }
        public Guid? BookingSnackId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public PaymentMethod PaymentMethod { get; set; }
    }
}
