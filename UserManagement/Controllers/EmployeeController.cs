using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void CreateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void UpdateEmployee(int id, Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}

