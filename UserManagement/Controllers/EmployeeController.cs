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
    public async Task<IEnumerable<EmployeeModel>> GetAll() =>
        await _employeeService.GetAll();

    [HttpGet("{employeeId}")]
    public async Task<EmployeeModel> GetEmployeeById(string employeeId) =>
        await _employeeService.GetEmployeeById(employeeId);

    [HttpPost]
    public async Task CreateEmployee(CreateEmployeeRequest request) =>
        await _employeeService.CreateEmployee(request);

    [HttpPut("{employeeId}")]
    public async Task UpdateEmployee(string employeeId, UpdateEmployeeRequest request) =>
        await _employeeService.UpdateEmployee(employeeId, request);

    [HttpDelete("{employeeId}")]
    public async Task DeleteEmployee(string employeeId) =>
        await _employeeService.DeleteEmployee(employeeId);
}

