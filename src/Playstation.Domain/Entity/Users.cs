using Playstation.Domain.Common;

namespace Playstation.Domain.Entity
{
    public class User: BaseEntity,IAuditedEntity
    {
        public UserRole Role { get; set; } = UserRole.User;
        public UserStatus Status { get; set; } = UserStatus.Inactive;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string FullName { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Salt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<OtpCode> OtpCodes { get; set; } = new List<OtpCode>();
    }

    public enum UserRole
    {
        SuperAdmin=1,
        Admin,
        User
    }
    public enum UserStatus
    {
        New = 1,
        Active,
        Inactive,
        Deleted
    }

}
