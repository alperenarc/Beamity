using Beamity.Application.Service.AuthenticationServices;
using System.Threading.Tasks;

namespace Beamity.Application.Service.IServices
{
    public interface IAuthenticationService
    {
         TokenResponse CreateAccessTokenAsync(string email, string password);
         TokenResponse RefreshTokenAsync(string refreshToken, string userEmail);
         void RevokeRefreshToken(string refreshToken);
    }
}