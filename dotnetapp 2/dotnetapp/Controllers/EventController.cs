
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authorization;

namespace dotnetapp.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [Authorize(Roles = "Organizer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }

        [Authorize(Roles = "Organizer")]

        [HttpGet("{eventId}")]
        public async Task<ActionResult<Event>> GetEventById(int eventId)
        {
            var @event = await _eventService.GetEventById(eventId);

            if (@event == null)
            {
                return NotFound(new { message = "Cannot find any event" });
            }

            return Ok(@event);
        }
        [Authorize(Roles = "Organizer")]

        [HttpPost]
        public async Task<ActionResult> AddEvent([FromBody] Event @event)
        {
            try
            {
                var success = await _eventService.AddEvent(@event);

                if (success)
                {
                    return Ok(new { message = "Event added successfully" });
                }
                else
                {
                    return StatusCode(500, new { message = "Failed to add event" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [Authorize(Roles = "Organizer")]

        [HttpPut("{eventId}")]
        public async Task<ActionResult> UpdateEvent(int eventId, [FromBody] Event @event)
        {
            try
            {
                var success = await _eventService.UpdateEvent(eventId, @event);

                if (success)
                {
                    return Ok(new { message = "Event updated successfully" });
                }
                else
                {
                    return NotFound(new { message = "Cannot find any event" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [Authorize(Roles = "Organizer")]

        [HttpDelete("{eventId}")]
        public async Task<ActionResult> DeleteEvent(int eventId)
        {
            try
            {
                var success = await _eventService.DeleteEvent(eventId);

                if (success)
                {
                    return Ok(new { message = "Event deleted successfully" });
                }
                else
                {
                    return NotFound(new { message = "Cannot find any event" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
