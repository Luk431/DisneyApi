using DisneyAppParte2.Models;

namespace DisneyAppParte2.Business.Services.TokenService
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
