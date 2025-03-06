using Playstation.Domain.Common;

namespace Playstation.Domain.Entity
{
    public class Snack:BaseEntity,IAuditedEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public ICollection<BookingSnack> BookingSnacks { get; set; } = new List<BookingSnack>();
    }

}
