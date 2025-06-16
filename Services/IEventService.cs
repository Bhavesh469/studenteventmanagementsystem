using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Models;

namespace StudentEventManagementSystem.Services;

public interface IEventService
{
    Task<IEnumerable<Event>> GetAllEventsAsync();
    Task<Event?> GetEventByIdAsync(int id);
    Task<Event> CreateEventAsync(EventDTO eventDto);
    Task<bool> UpdateEventAsync(int id, EventDTO eventDto);
    Task<bool> DeleteEventAsync(int id);
}
