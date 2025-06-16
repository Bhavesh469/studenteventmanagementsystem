using Microsoft.AspNetCore.Mvc;
using StudentEventManagementSystem.Models;
using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Services.Interfaces; // or your actual service namespace

namespace StudentEventManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAll()
    {
        var students = await _studentService.GetAllAsync();
        return Ok(students);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> AddStudent(StudentDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var student = await _studentService.AddAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = student.Id }, student);
    }
}
