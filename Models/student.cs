using System.ComponentModel.DataAnnotations;

namespace StudentEventManagementSystem.Models;

public class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
