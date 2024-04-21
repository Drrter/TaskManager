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
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _commentsService;

        public CommentsController(CommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comments>>> GetAllComments()
        {
            var comments = await _commentsService.GetAllComments();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comments>> GetCommentsById(int id)
        {
            var @comments = await _commentsService.GetCommentsById(id);
            if (@comments == null)
            {
                return NotFound();
            }
            return @comments;
        }
        [HttpPost]
        public async Task<ActionResult<Comments>> AddComment(Comments newComment)
        {
            await _commentsService.AddComment(newComment);
            return CreatedAtAction(nameof(GetCommentsById), new { id = newComment.IdComment }, newComment);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, Comments updatedComment)
        {
            if (id != updatedComment.IdComment)
            {
                return BadRequest();
            }

            await _commentsService.UpdateComment(updatedComment);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var commentToDelete = await _commentsService.GetCommentsById(id);
            if (commentToDelete == null)
            {
                return NotFound();
            }

            await _commentsService.DeleteComment(id);

            return NoContent();
        }
    }
}
