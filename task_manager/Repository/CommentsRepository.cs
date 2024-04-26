using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Реализация репозитория ICommentsRepository
    /// </summary>
    public class CommentsRepository : ICommentsRepository
    {
        /// <summary>
        /// Передает TaskContext в конструктор
        /// </summary>
        private readonly TaskContext _context;

        public CommentsRepository(TaskContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает список всех комментариев
        /// </summary>
        /// <returns>Список комментариев</returns>
        public async Task<List<Comments>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            return await _context.Comments.ToListAsync(cancellationToken);
        }
        /// <summary>
        /// Получает комментарий по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <returns>Комментарий по указанному идентификатору</returns>
        public async Task<Comments> GetCommentsByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Comments.FindAsync(id,cancellationToken);
        }
        /// <summary>
        /// Добавление комментария
        /// </summary>
        /// <param name="newComment">Новый комментарий </param>
        /// <returns>Выполнено</returns>
        public async Task AddCommentAsync(Comments newComment,CancellationToken cancellationToken)
        {
            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Изменение комментария
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <param name="updatedComment">Обновленный комментарий</param>
        /// <returns>Выполнено</returns>
        public async Task UpdateCommentAsync(int id, Comments updatedComment, CancellationToken cancellationToken)
        {
            _context.Entry(updatedComment).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteCommentAsync(int id,CancellationToken cancellationToken)
        {
            var commentToDelete = await _context.Comments.FindAsync(id,cancellationToken);
            if (commentToDelete != null)
            {
                _context.Comments.Remove(commentToDelete);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }

}
