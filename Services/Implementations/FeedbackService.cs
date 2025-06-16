using Microsoft.EntityFrameworkCore;
using StudentEventManagementSystem.Data;
using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Models;

namespace StudentEventManagementSystem.Services.Implementations;

public class FeedbackService : IFeedbackService
{
    private readonly ApplicationDbContext _context;

    public FeedbackService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> SubmitFeedbackAsync(FeedbackDTO dto)
    {
        var ev = await _context.Events.FindAsync(dto.EventId);
        if (ev == null) return "Event not found.";

        if (DateTime.Now < ev.Date)
            return "Feedback can only be submitted after the event date.";

        var feedback = new Feedback
        {
            EventId = dto.EventId,
            Rating = dto.Rating,
            Comment = dto.Comment,
            SubmittedOn = DateTime.Now
        };

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return "Feedback submitted successfully.";
    }
}
