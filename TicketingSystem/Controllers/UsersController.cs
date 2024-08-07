using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Services.DTOs;
using TicketingSystem.Services.IServices;

namespace TicketingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromBody] UserFiltersDTO Filters)
        {
            var users = await _userService.GetUsersAsync(Filters);
            return Ok(new {users = users, count = users.Count()});
        }

        [HttpGet("Seed")]
        public IActionResult Seed()
        {
            _userService.SeedUsersTable();
            return Ok();
        }
    }
}
