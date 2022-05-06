using AuthService.Models;
using AuthService.Repository;
using AuthService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
           
            this.userService = userService;
        }


        /// <summary>
        /// Post method for Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Login([FromBody] LoginCredentials login)
        {
          
            //_log4net.Info("Login initiated!");
            IActionResult response = Unauthorized();

            var user = userService.AuthenticateUser(login);
            if (user == null)
            {
                return NotFound(new CustomResponse(401, "Invalid Credential"));
            }
            else
            {
                var tokenString = userService.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }





    }
}
