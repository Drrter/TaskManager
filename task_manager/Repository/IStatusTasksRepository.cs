using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления статусами
    /// </summary>
    public interface IStatusTasksRepository
    {
        /// <summary>
        /// Получает список всех статусов
        /// </summary>
        /// <returns>Список статусов</returns>
        Task<List<StatusTask>> GetAllStatusAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает статус по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор статуса</param>
        /// <returns>Статус с указанным идентификатором</returns>
        Task<StatusTask> GetStatusByIdAsync(int id,CancellationToken cancellationToken);
    }
    
}
