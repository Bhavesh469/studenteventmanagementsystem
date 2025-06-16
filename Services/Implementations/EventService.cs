using Microsoft.EntityFrameworkCore;
using StudentEventManagementSystem.Data;
using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Models;

namespace StudentEventManagementSystem.Services.Implementations;

public class EventService : IEventService
{
    private readonly ApplicationDbContext _context;

    public EventService(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ Now includes Feedbacks and Registrations
    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Events
            .Include(e => e.Feedbacks)
            .Include(e => e.Registrations)
                .ThenInclude(r => r.Student) // Optional: include student in registration
            .ToListAsync();
    }

    // ✅ Now includes Feedbacks and Registrations for a single event
    public async Task<Event?> GetEventByIdAsync(int id)
    {
        return await _context.Events
            .Include(e => e.Feedbacks)
            .Include(e => e.Registrations)
                .ThenInclude(r => r.Student)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Event> CreateEventAsync(EventDTO eventDto)
    {
        var ev = new Event
        {
            Name = eventDto.Name,
            Venue = eventDto.Venue,
            Date = eventDto.Date
        };

        _context.Events.Add(ev);
        await _context.SaveChangesAsync();
        return ev;
    }

    public async Task<bool> UpdateEventAsync(int id, EventDTO eventDto)
    {
        var ev = await _context.Events.FindAsync(id);
        if (ev == null) return false;

        ev.Name = eventDto.Name;
        ev.Venue = eventDto.Venue;
        ev.Date = eventDto.Date;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEventAsync(int id)
    {
        var ev = await _context.Events.FindAsync(id);
        if (ev == null) return false;

        _context.Events.Remove(ev);
        await _context.SaveChangesAsync();
        return true;
    }
}
