using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager;
using TaskManager.DB;
using TaskManager.Repository;
using TaskManager.Services;


namespace TaskManager.Controllers
{
    /// <summary>
    /// Конструктор для работы с событиями
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;
        /// <summary>
        /// Конструктор контроллера EventsController
        /// </summary>
        /// <param name="eventService">Сервис событий</param>
        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }
        /// <summary>
        /// Получить список всех событий
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список событий</returns>
        [HttpGet]
        public async Task<ActionResult<List<Events>>> GetAllEventsAsync(CancellationToken cancellationToken)
        {
            var events = await _eventService.GetAllEventsAsync(cancellationToken);
            return Ok(events);
        }
        /// <summary>
        /// Получить событие по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Событий по указанному идентификатору</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Events>> GetEventByIdAsync(int id,CancellationToken cancellationToken)
        {
            var @event = await _eventService.GetEventByIdAsync(id,cancellationToken);
            if (@event == null)
            {
                return NotFound();
            }
            return @event;
        }
        /// <summary>
        /// Добавить новое событие
        /// </summary>
        /// <param name="newEvent">Новое событие</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPost]
        public async Task<ActionResult<Events>> AddEventAsync(Events newEvent,CancellationToken cancellationToken)
        {
            await _eventService.AddEventAsync(newEvent,cancellationToken);
            return CreatedAtAction(nameof(GetEventByIdAsync), new { id = newEvent.Id }, newEvent);
        }
        /// <summary>
        /// Обновление существующего события
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <param name="updatedEvent">Обновленное событие</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEventAsync(int id, Events updatedEvent,CancellationToken cancellationToken)
        {
            if (id != updatedEvent.Id)
            {
                return BadRequest();
            }

            await _eventService.UpdateEventAsync(updatedEvent,cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// Удаление события
        /// </summary>
        /// <param name="id">Идентификатор события</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Выполнено</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventAsync(int id,CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventService.GetEventByIdAsync(id,cancellationToken);
            if (eventToDelete == null)
            {
                return NotFound();
            }
            
            await _eventService.DeleteEventAsync(id,cancellationToken);

            return NoContent();
        }

    }
}
