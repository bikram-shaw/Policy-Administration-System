using AuthService.Data;
using AuthService.Data.Entities;
using System.Linq;

namespace AuthService.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AuthServiceContext context;

        public UserRepo(AuthServiceContext context)
        {
            this.context = context;
        }

        public User GetUserCred(User user)
        {
            return context.Users.Where(u=>u.Username==user.Username && u.Password==user.Password).FirstOrDefault();
        }
    }
}
