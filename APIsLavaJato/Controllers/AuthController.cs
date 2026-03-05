using APIsNET.Services;
using Microsoft.AspNetCore.Mvc;
using APIsNET.Domain.Model;

namespace APIsNET.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "isaac" && password == "1234")
            {
                var token = TokenService.GenerateToken(new APIsNET.Domain.Model.Employee());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
