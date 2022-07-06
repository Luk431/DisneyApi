using DisneyAppParte2.Business.Services.UserService;
using DisneyAppParte2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAppParte2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userService.GetUsers());
        }
        [HttpGet("byid")]
        public ActionResult<User> GetUser(int id)
        {
            return Ok(_userService.GetUsers().Where(u => u.Id == id));
        }
    }
}
