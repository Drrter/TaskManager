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


namespace TaskManager.Controllers
{
    /// <summary>
    /// конструктор для работы с событиями
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;
        /// <summary>
        /// конструктор контроллера EventsController
        /// </summary>
        /// <param name="eventService">сервис событий</param>
        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }
        /// <summary>
        /// получить список всех событий
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Events>>> GetAllEventsAsync(CancellationToken cancellationToken)
        {
            var events = await _eventService.GetAllEventsAsync(cancellationToken);
            return Ok(events);
        }
        /// <summary>
        /// получить событие по идентификатору
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
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
        /// добавить новое событие
        /// </summary>
        /// <param name="newEvent">новое событие</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Events>> AddEventAsync(Events newEvent,CancellationToken cancellationToken)
        {
            await _eventService.AddEventAsync(newEvent,cancellationToken);
            return CreatedAtAction(nameof(GetEventByIdAsync), new { id = newEvent.IdEvent }, newEvent);
        }
        /// <summary>
        /// обновление существующего события
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <param name="updatedEvent">обновленное событие</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEventAsync(int id, Events updatedEvent,CancellationToken cancellationToken)
        {
            if (id != updatedEvent.IdEvent)
            {
                return BadRequest();
            }

            await _eventService.UpdateEventAsync(updatedEvent,cancellationToken);

            return NoContent();
        }
        /// <summary>
        /// удаление события
        /// </summary>
        /// <param name="id">идентификатор события</param>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns></returns>
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
