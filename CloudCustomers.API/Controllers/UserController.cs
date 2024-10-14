using CloudCustomers.API.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomers.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsers();

            if (users.Any())
            {
                return Ok(users);
            }

            return NotFound();
        }


    }
}
