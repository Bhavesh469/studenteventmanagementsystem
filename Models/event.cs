using System.ComponentModel.DataAnnotations;

namespace StudentEventManagementSystem.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Venue is required.")]
        [StringLength(100)]
        public string Venue { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime Date { get; set; }

        // ✅ Navigation properties
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
