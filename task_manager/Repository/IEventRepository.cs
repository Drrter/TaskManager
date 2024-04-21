using Microsoft.EntityFrameworkCore;
using TaskManager.DB;

namespace TaskManager.Repository
{
    public interface IEventRepository
    {
        Task<List<Events>> GetAllEvents();
        Task<Events> GetEventById(int id);
        Task AddEvent(Events newEvent);
        Task UpdateEvent(int id, Events updatedEvent);
        Task DeleteEvent(int id);
    }
    public class EventRepository : IEventRepository
    {
        private readonly TaskContext _context;

        public EventRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<Events>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Events> GetEventById(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task AddEvent(Events newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEvent(int id,Events updatedEvent)
        {
            _context.Entry(updatedEvent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEvent(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Events>> GetAllEvents()
        {
            return await _eventRepository.GetAllEvents();
        }

        public async Task<Events> GetEventById(int id)
        {
            return await _eventRepository.GetEventById(id);
        }
        public async Task AddEvent(Events newEvent)
        {
            await _eventRepository.AddEvent(newEvent);
        }

        public async Task UpdateEvent(Events updatedEvent)
        {
             await _eventRepository.UpdateEvent(updatedEvent.IdEvent, updatedEvent);
        }
        public async Task DeleteEvent(int id)
        {
            await _eventRepository.DeleteEvent(id);
        }
    }


}
