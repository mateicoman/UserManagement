using UserManagement.Domain.DTOs.Department;

namespace UserManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly ILogger<SiteController> _logger;
    private readonly IDepartmentService _departmentService;

    public DepartmentController(ILogger<SiteController> logger, IDepartmentService departmentService)
    {
        _logger = logger;
        _departmentService = departmentService;
    }

    /// <summary>
    /// Find all departments
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<DepartmentDto>> Find() =>
            await _departmentService.GetAll();

    [HttpGet("{departmentId}")]
    public async Task<DepartmentDto> GetDepartmentById(string departmentId) =>
        await _departmentService.GetDepartmentById(departmentId);
    [HttpPost]
    public async Task<IActionResult> CreateDepartment(DepartmentPostDto department)
    {
        await _departmentService.CreateDepartment(department);
        return Ok(new { message = "User created" });
    }
    [HttpPut("{departmentId}")]
    public async Task UpdateDepartment(string departmentId, DepartmentPutDto department) =>
            await _departmentService.UpdateDepartment(departmentId, department);

    [HttpDelete("{departmentId}")]
    public async Task DeleteDepartment(string departmentId) =>
            await _departmentService.DeleteDepartment(departmentId);
}

