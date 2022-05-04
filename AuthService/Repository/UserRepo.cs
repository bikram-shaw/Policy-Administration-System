using AuthService.Models;
using AuthService.Provider;

namespace AuthService.Repository
{
    public class UserRepo : IUserRepo
    {
        private IUserProvider _userProvider;

        public UserRepo(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public LoginCredentials GetUserCred(LoginCredentials cred)
        {
            return _userProvider.GetUser(cred);
        }
    }
}
