using Beamity.Application.Service.AuthenticationServices;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models.Tokens;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;


namespace Beamity.Application.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;
        
        public AuthenticationService(UserRepository userRepository, ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
            _userRepository = userRepository;
        }

        public TokenResponse CreateAccessTokenAsync(string email, string password)
        {
            var user = _userRepository.GetUserForLogin(email);


            if (user == null || !Helpers.PasswordHelper.ValidatePassword(password, user.Hash))
            {
                return new TokenResponse(false, "Invalid credentials.", null);
            }

            var token = _tokenHandler.CreateAccessToken(user);

            return new TokenResponse(true, null, token);
        }

        public  TokenResponse RefreshTokenAsync(string refreshToken, string userEmail)
        {
            var token = _tokenHandler.TakeRefreshToken(refreshToken);

            if (token == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            if (token.IsExpired())
            {
                return new TokenResponse(false, "Expired refresh token.", null);
            }

            var user =  _userRepository.GetUserForLogin(userEmail);
            if (user == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            var accessToken = _tokenHandler.CreateAccessToken(user);
            return new TokenResponse(true, null, accessToken);
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            _tokenHandler.RevokeRefreshToken(refreshToken);
        }
    }
}