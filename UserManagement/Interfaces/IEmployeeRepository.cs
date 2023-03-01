using System;
using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeModel>> GetAll();
        Task<EmployeeModel> GetEmployeeById(string employeeId);
        Task CreateEmployee(EmployeeModel employee);
        Task UpdateEmployee(string employeeId, EmployeeModel employee);
        Task DeleteEmployee(string employeeId);
    }
}

