using Microsoft.AspNetCore.Mvc;
using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Services;

namespace StudentEventManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _feedbackService;

    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitFeedback([FromBody] FeedbackDTO dto)
    {
        var result = await _feedbackService.SubmitFeedbackAsync(dto);
        if (result.Contains("not found") || result.Contains("only be submitted"))
            return BadRequest(result);

        return Ok(result);
    }
}
