using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// интерфейс с методами управления комментариями
    /// </summary>
    public interface ICommentsRepository
    {
        /// <summary>
        /// получает список всех комментариев
        /// </summary>
        /// <returns>список комментариев</returns>
        Task<List<Comments>> GetAllCommentsAsync();
        /// <summary>
        /// получает комментарий по идентификатору
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <returns>комментарий по указанному идентификатору</returns>
        Task<Comments> GetCommentsByIdAsync(int id);
        /// <summary>
        /// добавление комментария
        /// </summary>
        /// <param name="newComment">новый комментарий </param>
        /// <returns>выполнено</returns>
        Task AddCommentAsync(Comments newComment);
        /// <summary>
        /// изменение комментария
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <param name="updatedComment">обновленный комментарий</param>
        /// <returns>выполнено</returns>
        Task UpdateCommentAsync(int id, Comments updatedComment);
        /// <summary>
        /// удаление комментария
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <returns>выполнено</returns>
        Task DeleteCommentAsync(int id);
    }
    /// <summary>
    /// реализация репозитория ICommentsRepository
    /// </summary>
    public class CommentsRepository:ICommentsRepository
    {
        /// <summary>
        /// передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public CommentsRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// получает список всех комментариев
        /// </summary>
        /// <returns>список комментариев</returns>
        public async Task<List<Comments>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToListAsync();
        }
        /// <summary>
        /// получает комментарий по идентификатору
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <returns>комментарий по указанному идентификатору</returns>
        public async Task<Comments> GetCommentsByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
        /// <summary>
        /// добавление комментария
        /// </summary>
        /// <param name="newComment">новый комментарий </param>
        /// <returns>выполнено</returns>
        public async Task AddCommentAsync(Comments newComment)
        {
            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// изменение комментария
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <param name="updatedComment">обновленный комментарий</param>
        /// <returns>выполнено</returns>
        public async Task UpdateCommentAsync(int id, Comments updatedComment)
        {
            _context.Entry(updatedComment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// удаление комментария
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <returns>выполнено</returns>
        public async Task DeleteCommentAsync(int id)
        {
            var commentToDelete = await _context.Comments.FindAsync(id);
            if (commentToDelete != null)
            {
                _context.Comments.Remove(commentToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    /// <summary>
    /// сервис управления комментариями
    /// </summary>
    public class CommentsService
    {
        /// <summary>
        /// зависимость типа ICommentsRepository
        /// </summary>
        private readonly ICommentsRepository _commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }
        /// <summary>
        /// получает список всех комментариев
        /// </summary>
        /// <returns>список комментариев</returns>
        public async Task<List<Comments>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            return await _commentsRepository.GetAllCommentsAsync();
        }
        /// <summary>
        /// получает комментарий по идентификатору
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <returns>комментарий по указанному идентификатору</returns>
        public async Task<Comments> GetCommentsByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _commentsRepository.GetCommentsByIdAsync(id);
        }
        /// <summary>
        /// добавление комментария
        /// </summary>
        /// <param name="newComment">новый комментарий </param>
        /// <returns>выполнено</returns>
        public async Task AddCommentAsync(Comments newComment, CancellationToken cancellationToken)
        {
            await _commentsRepository.AddCommentAsync(newComment);
        }
        /// <summary>
        /// изменение комментария
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <param name="updatedComment">обновленный комментарий</param>
        /// <returns>выполнено</returns>
        public async Task UpdateCommentAsync(Comments updatedComment, CancellationToken cancellationToken)
        {
            await _commentsRepository.UpdateCommentAsync(updatedComment.IdComment, updatedComment);
        }
        /// <summary>
        /// удаление комментария
        /// </summary>
        /// <param name="id">идентификатор комментария</param>
        /// <returns>выполнено</returns>
        public async Task DeleteCommentAsync(int id, CancellationToken cancellationToken)
        {
            await _commentsRepository.DeleteCommentAsync(id);
        }
    }
}
