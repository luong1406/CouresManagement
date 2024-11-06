using API.DTO;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        [EnableQuery]
        public async Task<IActionResult> Login(User user)
        {
            var existingUser = await _userRepository.GetUserByEmail(user.Email);
            if (existingUser != null && existingUser.Password == user.Password)
            {
                return Ok(existingUser);
            }
            return Unauthorized("Invalid email or password!");
        }

        [HttpGet("getAllUser")]
        [EnableQuery]
        public async Task<IActionResult> getAllUser()
        {

            return Ok( await _userRepository.GetAllUser());
        }
        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (user == null)
                return BadRequest();

            await _userRepository.AddUser(user);
            return CreatedAtAction(nameof(getAllUser), new { id = user.UserId }, user);
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser( UserDTO user)
        {
            

            var existingUser = await _userRepository.GetUserByUserId(user.UserId);
            existingUser.Username = user.Username;
            existingUser.Email=user.Email;
            existingUser.Password = user.Password;
            existingUser.Role=user.Role;    
           

            await _userRepository.UpdateUser(existingUser);
            return NoContent();
        }

        [HttpDelete("deleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
           

            await _userRepository.DeleteUser(userId);
            return NoContent();
        }
        [HttpGet("getUserById/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserByUserId(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
