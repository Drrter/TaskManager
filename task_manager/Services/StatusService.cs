using TaskManager.DB;
using TaskManager.Repository;

namespace TaskManager.Services
{
    /// <summary>
    /// Сервис для управления статусами
    /// </summary>
    public class StatusService
    {
        /// <summary>
        /// Зависимость типа IStatusTasksRepository
        /// </summary>
        private readonly IStatusTasksRepository _statusTasksRepository;
        public StatusService(IStatusTasksRepository statusTasksRepository)
        {
            _statusTasksRepository = statusTasksRepository;
        }
        /// <summary>
        /// Получает список всех статусов
        /// </summary>
        /// <returns>Список статусов</returns>
        public async Task<List<StatusTask>> GetAllStatusAsync(CancellationToken cancellationToken)
        {
            
            return await _statusTasksRepository.GetAllStatusAsync(cancellationToken);
        }
        /// <summary>
        /// Получает статус по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор статуса</param>
        /// <returns>Статус с указанным идентификатором</returns>
        public async Task<StatusTask> GetStatusByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _statusTasksRepository.GetStatusByIdAsync(id, cancellationToken);
        }
    }

}
