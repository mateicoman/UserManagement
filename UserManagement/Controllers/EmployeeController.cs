using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Models.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll() =>
            await _employeeService.GetAll();

        [HttpGet("{employeeId}")]
        public async Task<Employee> GetEmployeeById(string employeeId) =>
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
}

