using System.ComponentModel.DataAnnotations;

namespace StudentEventManagementSystem.DTOs
{
    public class EventDTO
    {
        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(100, ErrorMessage = "Event name can't be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Venue is required.")]
        [StringLength(100, ErrorMessage = "Venue name can't be longer than 100 characters.")]
        public string Venue { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime Date { get; set; }
    }
}
