using StudentEventManagementSystem.Data;
using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Models;
using StudentEventManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StudentEventManagementSystem.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> AddAsync(StudentDTO studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Email = studentDto.Email
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
