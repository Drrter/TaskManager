using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    /// <summary>
    /// Интерфейс с методами управления приоритетами
    /// </summary>
    public interface IPrioritiesTaskRepository
    {
        /// <summary>
        /// Получает список всех приоритетов
        /// </summary>
        /// <returns>Список приоритетов</returns>
        Task<List<PrioritiesTask>> GetAllPriorityAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Получает приоритет по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор приоритета</param>
        /// <returns>Приоритет с указанным идентификатором</returns>
        Task<PrioritiesTask> GetPriorityByIdAsync(int id, CancellationToken cancellationToken);
    }
    
}
