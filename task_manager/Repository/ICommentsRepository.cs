using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface ICommentsRepository
    {
        Task<List<Comments>> GetAllComments();
        Task<Comments> GetCommentsById(int id);
        Task AddComment(Comments newComment);
        Task UpdateComment(int id, Comments updatedComment);
        Task DeleteComment(int id);
    }
    public class CommentsRepository:ICommentsRepository
    {
        private readonly TaskContext _context;

        public CommentsRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<Comments>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comments> GetCommentsById(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task AddComment(Comments newComment)
        {
            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComment(int id, Comments updatedComment)
        {
            _context.Entry(updatedComment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComment(int id)
        {
            var commentToDelete = await _context.Comments.FindAsync(id);
            if (commentToDelete != null)
            {
                _context.Comments.Remove(commentToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class CommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task<List<Comments>> GetAllComments()
        {
            return await _commentsRepository.GetAllComments();
        }

        public async Task<Comments> GetCommentsById(int id)
        {
            return await _commentsRepository.GetCommentsById(id);
        }
        public async Task AddComment(Comments newComment)
        {
            await _commentsRepository.AddComment(newComment);
        }

        public async Task UpdateComment(Comments updatedComment)
        {
            await _commentsRepository.UpdateComment(updatedComment.IdComment, updatedComment);
        }
        public async Task DeleteComment(int id)
        {
            await _commentsRepository.DeleteComment(id);
        }
    }
}
