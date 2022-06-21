using Machinego_Demo.Models;
using Machinego_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Machinego_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("Login")]
        public string LoginUser(LoginViewModel loginModel)
        {
            return this.userService.LoginUser(loginModel);
        }
    }
}
