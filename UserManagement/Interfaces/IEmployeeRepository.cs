using System;
using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetEmployeeById(string employeeId);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(string employeeId, Employee employee);
        Task DeleteEmployee(string employeeId);
    }
}

