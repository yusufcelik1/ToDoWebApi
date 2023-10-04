using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections.Generic;

namespace EvoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        // GET: api/User/5
        [HttpGet("GetUserByID")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        [HttpPost("CreateUser")]
        public ActionResult<User> PostUser(User user)
        {
            var createdUser = _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.ID }, createdUser);
        }

        // PUT: api/User/5
        [HttpPut("UpdateUser")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }
            var updatedUser = _userService.UpdateUser(user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
