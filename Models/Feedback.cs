using StudentEventManagementSystem.Models;

namespace StudentEventManagementSystem.Models;

public class Feedback
{
    public int Id { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; } = null!;

    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;

    public DateTime SubmittedOn { get; set; }
}
