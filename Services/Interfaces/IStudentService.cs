using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Models;

namespace StudentEventManagementSystem.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> AddAsync(StudentDTO studentDto);
    }
}
