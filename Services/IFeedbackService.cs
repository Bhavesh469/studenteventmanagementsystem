using StudentEventManagementSystem.DTOs;

namespace StudentEventManagementSystem.Services;

public interface IFeedbackService
{
    Task<string> SubmitFeedbackAsync(FeedbackDTO dto);
}
