namespace Playstation.Shared
{
    public interface IClaimService
    {
        string GetUserId();

        string GetClaim(string key);
    }
}
