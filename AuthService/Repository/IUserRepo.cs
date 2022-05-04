using AuthService.Models;

namespace AuthService.Repository
{
    public interface IUserRepo
    {
        public LoginCredentials GetUserCred(LoginCredentials cred);
    }
}
