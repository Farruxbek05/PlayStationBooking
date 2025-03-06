namespace Playstation.Application.Models.Review
{
    public class ReviewUM
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookingId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public decimal AverageRating { get; set; }
    }
    public class ReviewUMResponce : BaseResponceModel { }
}
