using AuthService.Models;
using System.Collections.Generic;

namespace AuthService.Provider
{
    public interface IUserProvider
    {
        public List<LoginCredentials> GetList();

        public LoginCredentials GetUser(LoginCredentials cred);
    }
}
