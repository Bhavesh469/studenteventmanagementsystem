using Microsoft.AspNetCore.Mvc;
using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Models;
using StudentEventManagementSystem.Services;

namespace StudentEventManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
    {
        return Ok(await _eventService.GetAllEventsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var ev = await _eventService.GetEventByIdAsync(id);
        if (ev == null) return NotFound();
        return Ok(ev);
    }

    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent([FromBody] EventDTO eventDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _eventService.CreateEventAsync(eventDto);
        return CreatedAtAction(nameof(GetEvent), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventDTO eventDto)
    {
        var updated = await _eventService.UpdateEventAsync(id, eventDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var deleted = await _eventService.DeleteEventAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
