using Microsoft.EntityFrameworkCore;
using StudentEventManagementSystem.Data;
using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Models;

namespace StudentEventManagementSystem.Services.Implementations;

public class RegistrationService : IRegistrationService
{
    private readonly ApplicationDbContext _context;

    public RegistrationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> RegisterStudentAsync(RegistrationDTO dto)
    {
        // Check if student and event exist
        var student = await _context.Students.FindAsync(dto.StudentId);
        var ev = await _context.Events.FindAsync(dto.EventId);

        if (student == null || ev == null)
            return "Student or Event not found.";

        // Check for duplicate registration
        var existing = await _context.Registrations
            .AnyAsync(r => r.StudentId == dto.StudentId && r.EventId == dto.EventId);

        if (existing)
            return "Student already registered for this event.";

        // Register
        var reg = new Registration
        {
            StudentId = dto.StudentId,
            EventId = dto.EventId
        };

        _context.Registrations.Add(reg);
        await _context.SaveChangesAsync();

        return "Registration successful.";
    }
}
