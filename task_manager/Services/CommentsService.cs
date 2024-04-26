using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис управления комментариями
    /// </summary>
    public class CommentsService
    {
        /// <summary>
        /// Зависимость типа ICommentsRepository
        /// </summary>
        private readonly ICommentsRepository _commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }
        /// <summary>
        /// Получает список всех комментариев
        /// </summary>
        /// <returns>Список комментариев</returns>
        public async Task<List<Comments>> GetAllCommentsAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return new List<Comments>();
            }
            return await _commentsRepository.GetAllCommentsAsync(cancellationToken);
        }
        /// <summary>
        /// Получает комментарий по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <returns>Комментарий по указанному идентификатору</returns>
        public async Task<Comments> GetCommentsByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _commentsRepository.GetCommentsByIdAsync(id, cancellationToken);
        }
        /// <summary>
        /// Добавление комментария
        /// </summary>
        /// <param name="newComment">Новый комментарий </param>
        /// <returns>Выполнено</returns>
        public async Task AddCommentAsync(Comments newComment, CancellationToken cancellationToken)
        {
            await _commentsRepository.AddCommentAsync(newComment, cancellationToken);
        }
        /// <summary>
        /// Изменение комментария
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <param name="updatedComment">Обновленный комментарий</param>
        /// <returns>выполнено</returns>
        public async Task UpdateCommentAsync(Comments updatedComment, CancellationToken cancellationToken)
        {
            await _commentsRepository.UpdateCommentAsync(updatedComment.Id, updatedComment , cancellationToken);
        }
        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <param name="id">Идентификатор комментария</param>
        /// <returns>Выполнено</returns>
        public async Task DeleteCommentAsync(int id, CancellationToken cancellationToken)
        {
            await _commentsRepository.DeleteCommentAsync(id, cancellationToken);
        }
    }
}
