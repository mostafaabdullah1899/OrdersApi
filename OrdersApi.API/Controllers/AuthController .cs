using Microsoft.AspNetCore.Mvc;
using OrdersApi.Application.Interfaces;

namespace OrdersApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("token")]
        public IActionResult GetToken()
        {
            var token = _jwtService.GenerateToken("testuser"); 
            return Ok(new { token });
        }
    }
}
