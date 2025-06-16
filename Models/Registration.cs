using StudentEventManagementSystem.Models;

namespace StudentEventManagementSystem.Models;

public class Registration
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int EventId { get; set; }
    public Event Event { get; set; } = null!;
}
