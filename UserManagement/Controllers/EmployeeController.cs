using UserManagement.Domain.DTOs.Employee;

namespace UserManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IEnumerable<EmployeeDto>> GetAll() =>
        await _employeeService.GetAll();

    [HttpGet("{employeeId}")]
    public async Task<EmployeeDto> GetEmployeeById(string employeeId) =>
        await _employeeService.GetEmployeeById(employeeId);

    [HttpPost]
    public async Task CreateEmployee(EmployeePostDto request) =>
        await _employeeService.CreateEmployee(request);

    [HttpPut("{employeeId}")]
    public async Task UpdateEmployee(string employeeId, EmployeePutDto request) =>
        await _employeeService.UpdateEmployee(employeeId, request);

    [HttpDelete("{employeeId}")]
    public async Task DeleteEmployee(string employeeId) =>
        await _employeeService.DeleteEmployee(employeeId);
}

