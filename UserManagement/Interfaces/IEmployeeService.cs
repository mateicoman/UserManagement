﻿using System;
using UserManagement.Models;
using UserManagement.Models.Requests;

namespace UserManagement.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetAll();
        Task<EmployeeModel> GetEmployeeById(string employeeId);
        Task CreateEmployee(CreateEmployeeRequest request);
        Task UpdateEmployee(string employeeId, UpdateEmployeeRequest request);
        Task DeleteEmployee(string employeeId);
    }
}

