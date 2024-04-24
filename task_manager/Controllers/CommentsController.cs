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
    /// контроллер для работы с комментариями
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _commentsService;
        /// <summary>
        /// конструктор контроллера CommentsController
        /// </summary>
        /// <param name="commentsService">сервис комментариев</param>
        public CommentsController(CommentsService commentsService)
        {
            _commentsService = commentsService;
        }
        /// <summary>
        /// получить список всех комментариев
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Comments>>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            var comments = await _commentsService.GetAllCommentsAsync(cancellationToken);
            return Ok(comments);
        }
        /// <summary>
        /// получить комментарий по идентификатору
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
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
        /// добавить новый комментарий
        /// </summary>
        /// <param name="newComment">новый комментарий</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Comments>> AddCommentAsync(Comments newComment,CancellationToken cancellationToken)
        {
            await _commentsService.AddCommentAsync(newComment,cancellationToken);
            return CreatedAtAction(nameof(GetCommentsByIdAsync), new { id = newComment.IdComment }, newComment);
        }
        /// <summary>
        /// обновить существующий комментарий
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <param name="updatedComment">обновленный комментарий</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentAsync(int id, Comments updatedComment,CancellationToken cancellationToken)
        {
            if (id != updatedComment.IdComment)
            {
                return BadRequest();
            }

            await _commentsService.UpdateCommentAsync(updatedComment,cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// удалить комментарий 
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
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
