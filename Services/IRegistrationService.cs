using StudentEventManagementSystem.DTOs;

namespace StudentEventManagementSystem.Services;

public interface IRegistrationService
{
    Task<string> RegisterStudentAsync(RegistrationDTO dto);
}
