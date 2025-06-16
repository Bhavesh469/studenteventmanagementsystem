using Microsoft.AspNetCore.Mvc;
using StudentEventManagementSystem.DTOs;
using StudentEventManagementSystem.Services;

namespace StudentEventManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationsController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegistrationsController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterStudent([FromBody] RegistrationDTO dto)
    {
        var result = await _registrationService.RegisterStudentAsync(dto);
        if (result.Contains("not found") || result.Contains("already"))
            return BadRequest(result);

        return Ok(result);
    }
}
