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
    /// Контроллер для работы с комментариями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _commentsService;
        /// <summary>
        /// Конструктор контроллера CommentsController
        /// </summary>
        /// <param name="commentsService">Сервис комментариев</param>
        public CommentsController(CommentsService commentsService)
        {
            _commentsService = commentsService;
        }
        /// <summary>
        /// Получить список всех комментариев
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список комментариев</returns>
        [HttpGet]
        public async Task<ActionResult<List<Comments>>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            var comments = await _commentsService.GetAllCommentsAsync(cancellationToken);
            return Ok(comments);
        }
        /// <summary>
        /// Получить комментарий по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Комментарий по указанному идентификатору</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Comments>> GetCommentsByIdAsync(int id,CancellationToken cancellationToken)
        {

            var @comments = await _commentsService.GetCommentsByIdAsync(id,cancellationToken);
            if (@comments == null)
            {
                return NotFound();
            }
            return @comments;
        }
        /// <summary>
        /// Добавить новый комментарий
        /// </summary>
        /// <param name="newComment">Новый комментарий</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPost]
        public async Task<ActionResult<Comments>> AddCommentAsync(Comments newComment,CancellationToken cancellationToken)
        {
            await _commentsService.AddCommentAsync(newComment,cancellationToken);
            return CreatedAtAction(nameof(GetCommentsByIdAsync), new { id = newComment.Id }, newComment);
        }
        /// <summary>
        /// Обновить существующий комментарий
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <param name="updatedComment">Обновленный комментарий</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentAsync(int id, Comments updatedComment,CancellationToken cancellationToken)
        {
            if (id != updatedComment.Id)
            {
                return BadRequest();
            }

            await _commentsService.UpdateCommentAsync(updatedComment,cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// Удалить комментарий 
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentAsync(int id,CancellationToken cancellationToken)
        {
            var commentToDelete = await _commentsService.GetCommentsByIdAsync(id,cancellationToken);
            if (commentToDelete == null)
            {
                return NotFound();
            }

            await _commentsService.DeleteCommentAsync(id,cancellationToken);

            return NoContent();
        }
    }
}
