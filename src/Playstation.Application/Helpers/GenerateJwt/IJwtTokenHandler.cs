using Playstation.Domain.Entity;

namespace Playstation.Application.Helpers.GenerateJwt
{
    public interface IJwtTokenHandler
    {
        string GenerateAccessToken(User user, string sessionToken);
        string GenerateRefreshToken();
    }

}
