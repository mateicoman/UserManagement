using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(ILogger<DepartmentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Department>> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<IEnumerable<Department>> GetDepartmentById(int departmentId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IEnumerable<Department>> CreateDepartment(Department department)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public async Task<IEnumerable<Department>> UpdateDepartment(int departmentId, Department department)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IEnumerable<Department>> DeleteDepartment(int departmentId)
    {
        throw new NotImplementedException();
    }
}

