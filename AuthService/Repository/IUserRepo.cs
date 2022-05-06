using AuthService.Data;
using AuthService.Models;

namespace AuthService.Repository
{
    public interface IUserRepo
    {
        public User GetUserCred(User user);
    }
}
