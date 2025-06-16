using System.ComponentModel.DataAnnotations;

namespace StudentEventManagementSystem.DTOs
{
    public class StudentDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;
    }
}
