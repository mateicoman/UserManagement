using System;
using UserManagement.Models;
using UserManagement.Models.Requests;

namespace UserManagement.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetEmployeeById(string employeeId);
        Task CreateEmployee(CreateEmployeeRequest request);
        Task UpdateEmployee(string employeeId, UpdateEmployeeRequest request);
        Task DeleteEmployee(string employeeId);
    }
}

