using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис для управления приоритетами
    /// </summary>
    public class PrioritiesService
    {
        /// <summary>
        /// Зависимость типа IPrioritiesTaskRepository
        /// </summary>
        private readonly IPrioritiesTaskRepository _prioritiesTaskRepository;

        public PrioritiesService(IPrioritiesTaskRepository prioritiesTaskRepository)
        {
            _prioritiesTaskRepository = prioritiesTaskRepository;
        }
        /// <summary>
        /// Получает список всех приоритетов
        /// </summary>
        /// <returns>Список приоритетов</returns>
        public async Task<List<PrioritiesTask>> GetAllPriorityAsync(CancellationToken cancellationToken)
        {
            return await _prioritiesTaskRepository.GetAllPriorityAsync(cancellationToken);
        }
        /// <summary>
        /// Получает приоритет по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор приоритета</param>
        /// <returns>Приоритет с указанным идентификатором</returns>
        public async Task<PrioritiesTask> GetPriorityByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _prioritiesTaskRepository.GetPriorityByIdAsync(id, cancellationToken);
        }
    }
}
