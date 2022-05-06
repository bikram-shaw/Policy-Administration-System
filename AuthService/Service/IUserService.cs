using AuthService.Models;

namespace AuthService.Service
{
    public interface IUserService
    {
        public LoginCredentials AuthenticateUser(LoginCredentials cred);
        public string GenerateJSONWebToken(LoginCredentials userInfo);
    }
}
