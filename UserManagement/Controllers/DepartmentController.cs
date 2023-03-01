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

    [HttpGet]
    public async Task<IEnumerable<DepartmentModel>> GetAll() =>
            await _departmentService.GetAll();

    [HttpGet("{departmentId}")]
    public async Task<DepartmentModel> GetDepartmentById(string departmentId) =>
        await _departmentService.GetDepartmentById(departmentId);
    [HttpPost]
    public async Task<IActionResult> CreateDepartment(CreateDepartmentRequest department)
    {
        await _departmentService.CreateDepartment(department);
        return Ok(new { message = "User created" });
    }
    [HttpPut("{departmentId}")]
    public async Task UpdateDepartment(string departmentId, UpdateDepartmentRequest department) =>
            await _departmentService.UpdateDepartment(departmentId, department);

    [HttpDelete("{departmentId}")]
    public async Task DeleteDepartment(string departmentId) =>
            await _departmentService.DeleteDepartment(departmentId);
}

