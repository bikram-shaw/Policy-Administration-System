using AuthService.Data;
using AuthService.Data.Entities;
using System.Linq;

namespace AuthService.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AuthServiceContext authServiceContext;
        

        public UserRepo(AuthServiceContext authServiceContext)
        {
            this.authServiceContext = authServiceContext;
        }

        public User GetUserCred(User user)
        { 
            return authServiceContext.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            
        }

        
    }
}
