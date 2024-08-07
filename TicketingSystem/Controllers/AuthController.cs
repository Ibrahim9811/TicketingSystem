using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Data.IServices;
using TicketingSystem.Services.DTOs;

namespace TicketingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

         private readonly IAuth _authService;

        public AuthController(IAuth authService)
        {
            _authService = authService;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
