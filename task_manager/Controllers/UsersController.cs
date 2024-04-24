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
    /// <summary>
    /// контроллер для работы с пользователями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        /// <summary>
        /// конструктор контроллера UsersController
        /// </summary>
        /// <param name="userService">сервис пользователей</param>
        public UsersController(UsersService userService)
        {
            _usersService = userService;
        }
        /// <summary>
        /// получить всех пользователей
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var users = await _usersService.GetAllUsersAsync(cancellationToken);
            return Ok(users);
        }
        /// <summary>
        /// получить пользователей по идентификатору
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            var @user = await _usersService.GetUserByIdAsync(id, cancellationToken);
            if (@user == null)
            {
                return NotFound();
            }
            return @user;
        }
        /// <summary>
        /// добавить нового пользователя
        /// </summary>
        /// <param name="newUser">новый пользователь</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Users>> AddUserAsync(Users newUser, CancellationToken cancellationToken )
        {
            await _usersService.AddUserAsync(newUser,cancellationToken);
            return CreatedAtAction(nameof(GetUserByIdAsync), new { id = newUser.IdUser }, newUser);
        }
        /// <summary>
        /// обновить данные пользователя
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <param name="updatedUser">обновленный пользователь</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, Users updatedUser, CancellationToken cancellationToken)
        {
            if (id != updatedUser.IdUser)
            {
                return BadRequest();
            }

            await _usersService.UpdateUserAsync(updatedUser, cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// удалить пользователя
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            var userToDelete = await _usersService.GetUserByIdAsync(id, cancellationToken);
            if (userToDelete == null)
            {
                return NotFound();
            }

            await _usersService.DeleteUserAsync(id, cancellationToken);

            return NoContent();
        }

    }
}
