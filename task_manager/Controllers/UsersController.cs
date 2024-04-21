using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager;
using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService userService)
        {
            _usersService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            var users = await _usersService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            var @user = await _usersService.GetUserById(id);
            if (@user == null)
            {
                return NotFound();
            }
            return @user;
        }
        [HttpPost]
        public async Task<ActionResult<Users>> AddUser(Users newUser)
        {
            await _usersService.AddUser(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.IdUser }, newUser);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, Users updatedUser)
        {
            if (id != updatedUser.IdUser)
            {
                return BadRequest();
            }

            await _usersService.UpdateUser(updatedUser);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = await _usersService.GetUserById(id);
            if (userToDelete == null)
            {
                return NotFound();
            }

            await _usersService.DeleteUser(id);

            return NoContent();
        }

    }
}
