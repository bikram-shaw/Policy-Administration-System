using AuthService.Models;
using AuthService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserRepo _repo;

        public AuthController(IConfiguration config, IUserRepo repo)
        {
            _config = config;
            _repo = repo;
        }


        /// <summary>
        /// Post method for Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Login([FromBody] LoginCredentials login)
        {
            AuthRepo auth_repo = new AuthRepo(_config, _repo);
            //_log4net.Info("Login initiated!");
            IActionResult response = Unauthorized();
            //login.FullName = "user1";
            var user = auth_repo.AuthenticateUser(login);
            if (user == null)
            {
                return NotFound(new CustomResponse(401, "Invalid Credential"));
            }
            else
            {
                var tokenString = auth_repo.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }





    }
}
