using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления комментариями
    /// </summary>
    public interface ICommentsRepository
    {
        /// <summary>
        /// Получает список всех комментариев
        /// </summary>
        /// <returns>Список комментариев</returns>
        Task<List<Comments>> GetAllCommentsAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает комментарий по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <returns>Комментарий по указанному идентификатору</returns>
        Task<Comments> GetCommentsByIdAsync(int id, CancellationToken cancellationToken);
        /// <summary>
        /// Добавление комментария
        /// </summary>
        /// <param name="newComment">Новый комментарий </param>
        /// <returns>Выполнено</returns>
        Task AddCommentAsync(Comments newComment, CancellationToken cancellationToken);
        /// <summary>
        /// Изменение комментария
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <param name="updatedComment">Обновленный комментарий</param>
        /// <returns>Выполнено</returns>
        Task UpdateCommentAsync(int id, Comments updatedComment, CancellationToken cancellationToken);
        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <returns>Выполнено</returns>
        Task DeleteCommentAsync(int id, CancellationToken cancellationToken);
    }
    
}
