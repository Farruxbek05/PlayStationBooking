namespace Playstation.Application.Models.BookingSnack
{
    public class BookingSnackUM
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public Guid SnackId { get; set; }
        public int Quantity { get; set; }
    }
    public class UpdateBookingSnackResponceModel : BaseResponceModel { }
}
