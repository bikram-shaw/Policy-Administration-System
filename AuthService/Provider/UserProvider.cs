using AuthService.Models;
using System.Collections.Generic;
using System.Linq;

namespace AuthService.Provider
{
    public class UserProvider : IUserProvider
    {
        private static List<LoginCredentials> credentials = new List<LoginCredentials>()
        {
            new LoginCredentials("user1","user1"),
            new LoginCredentials("user2","user2"),
            new LoginCredentials("user3","user4"),
            new LoginCredentials("user","user")
        };
        public List<LoginCredentials> GetList()
        {
            return credentials;
        }

        public LoginCredentials GetUser(LoginCredentials cred)
        {
            if (cred == null)
                return null;
            else
            {
                LoginCredentials user = credentials.FirstOrDefault(user => user.Username == cred.Username && user.Password == cred.Password);
                return user;
            }

        }
    }
}
