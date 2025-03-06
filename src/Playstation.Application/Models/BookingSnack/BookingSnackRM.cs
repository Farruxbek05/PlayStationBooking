namespace Playstation.Application.Models.BookingSnack
{
    public class BookingSnackRM:BaseResponceModel
    {
        public Guid BookingId { get; set; }
        public Guid SnackId { get; set; }
        public int Quantity { get; set; }
    }
}
