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
using TaskManager.Services;

namespace TaskManager.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        /// <summary>
        /// Конструктор контроллера UsersController
        /// </summary>
        /// <param name="userService">Сервис пользователей</param>
        public UsersController(UsersService userService)
        {
            _usersService = userService;
        }
        /// <summary>
        /// Получить список всех пользователей
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var users = await _usersService.GetAllUsersAsync(cancellationToken);
            return Ok(users);
        }
        /// <summary>
        /// Получить пользователей по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Пользователь по указанному идентификатору</returns>
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
        /// Добавить нового пользователя
        /// </summary>
        /// <param name="newUser">Новый пользователь</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPost]
        public async Task<ActionResult<Users>> AddUserAsync(Users newUser, CancellationToken cancellationToken )
        {
            await _usersService.AddUserAsync(newUser,cancellationToken);
            return CreatedAtAction(nameof(GetUserByIdAsync), new { id = newUser.Id }, newUser);
        }
        /// <summary>
        /// Обновить данные пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="updatedUser">Обновленный пользователь</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, Users updatedUser, CancellationToken cancellationToken)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest();
            }

            await _usersService.UpdateUserAsync(updatedUser, cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
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
