namespace Playstation.Application.Models.BookingSnack
{
    public class BookingSnackCM
    {
        public Guid BookingId { get; set; }
        public Guid SnackId { get; set; }
        public int Quantity { get; set; }

    }
    public  class CreateBookingSnackResponceModel : BaseResponceModel { }
}
