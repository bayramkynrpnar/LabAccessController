using Data.Model;
using Dto.User;
using Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.User;

namespace LabAccessController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("user")]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            userService.AddUser(addUserDto);
            return Ok();
        }

        [HttpDelete("user")]
        public IActionResult DeleteUser(int userId)
        {
            var result = userService.DeleteUser(userId);
            return Ok();
        }

        [HttpPut("user")]
        public IActionResult UpdateUser(UpdateUserDto updateUser)
        {
            var result = userService.UpdateUser(updateUser);
            return Ok();
        }

        [HttpGet("user")]
        public IActionResult GetUser(int userId)
        {
            var user = userService.GetUser(userId);
            return Ok(user);
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = userService.GetAllUser();
            return Ok(users);
        }
    }
}