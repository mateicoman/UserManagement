using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetAll() =>
            await _employeeRepository.GetAll();

        public async Task<Employee> GetEmployeeById(string employeeId)
        {
            if (employeeId is null)
            {
                throw new BadHttpRequestException("Employee Id is missing!");
            }
            var department = await _employeeRepository.GetEmployeeById(employeeId);

            return department;
        }
        public async Task CreateEmployee(Employee employee) =>
                await _employeeRepository.CreateEmployee(employee);

        public async Task UpdateEmployee(string employeeId, Employee employee) =>
                await _employeeRepository.UpdateEmployee(employeeId, employee);

        public async Task DeleteEmployee(string employeeId) =>
                await _employeeRepository.DeleteEmployee(employeeId);
    }
}

