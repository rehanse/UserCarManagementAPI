using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCarManagementAPI.Domain.Identity;
using UserCarManagementAPI.Domain.Interfaces;

namespace UserCarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }
        [HttpPost("UserRegister")]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            var result = await authService.RegisterAsync(registerModel);
            if (result.statusCode == 0)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("UserLogIn")]
        public async Task<IActionResult> Login(LoginModel model)
        {

            var result = await authService.LoginAsync(model);
            if (result.statusCode == 0)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
