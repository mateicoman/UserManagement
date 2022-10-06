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
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<Department>> GetAll() =>
            await _departmentRepository.GetAll();

        public async Task<Department> GetDepartmentById(string departmentId)
        {
            if (departmentId is null)
            {
                throw new BadHttpRequestException("Department Id is missing!");
            }
            var department = await _departmentRepository.GetDepartmentById(departmentId);

            return department;
        }
        public async Task CreateDepartment(Department department) =>
                await _departmentRepository.CreateDepartment(department);

        public async Task UpdateDepartment(string departmentId, Department department) =>
                await _departmentRepository.UpdateDepartment(departmentId, department);

        public async Task DeleteDepartment(string departmentId) =>
                await _departmentRepository.DeleteDepartment(departmentId);
    }
}

