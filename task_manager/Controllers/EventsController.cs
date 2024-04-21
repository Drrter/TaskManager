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
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Events>>> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Events>> GetEventById(int id)
        {
            var @event = await _eventService.GetEventById(id);
            if (@event == null)
            {
                return NotFound();
            }
            return @event;
        }
        [HttpPost]
        public async Task<ActionResult<Events>> AddEvent(Events newEvent)
        {
            await _eventService.AddEvent(newEvent);
            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.IdEvent }, newEvent);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Events updatedEvent)
        {
            if (id != updatedEvent.IdEvent)
            {
                return BadRequest();
            }

            await _eventService.UpdateEvent(updatedEvent);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventToDelete = await _eventService.GetEventById(id);
            if (eventToDelete == null)
            {
                return NotFound();
            }

            await _eventService.DeleteEvent(id);

            return NoContent();
        }

    }
}
