namespace Playstation.Application.Models.User;

public class UserSettings
{
    public int OtpExpirationTimeInSeconds { get; set; }
    public int OtpResendTimeInSeconds { get; set; }
    public int RefreshTokenExpirationDays { get; set; }
}
