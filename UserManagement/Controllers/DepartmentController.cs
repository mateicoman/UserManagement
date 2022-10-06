using Microsoft.AspNetCore.Mvc;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly ILogger<DepartmentController> _logger;
    private readonly IDepartmentService _departmentService;

    public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
    {
        _logger = logger;
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IEnumerable<Department>> GetAll() =>
            await _departmentService.GetAll();

    [HttpGet("{departmentId}")]
    public async Task<ActionResult<Department>> GetDepartmentById(string departmentId) =>
        await _departmentService.GetDepartmentById(departmentId);
    [HttpPost]
    public async Task<IActionResult> CreateDepartment(Department department)
    {
        await _departmentService.CreateDepartment(department);
        return CreatedAtAction(nameof(GetDepartmentById), new { departmentId = department.Id }, department);
    }
    [HttpPut("{departmentId}")]
    public async Task UpdateDepartment(string departmentId, Department department) =>
            await _departmentService.UpdateDepartment(departmentId, department);

    [HttpDelete("{departmentId}")]
    public async Task DeleteDepartment(string departmentId) =>
            await _departmentService.DeleteDepartment(departmentId);
}

