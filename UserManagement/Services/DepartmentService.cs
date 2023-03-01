using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Interfaces;
using UserManagement.Models;
using UserManagement.Models.Requests;

namespace UserManagement.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Department>> GetAll() =>
            await _departmentRepository.GetAll();

        public async Task<Department> GetDepartmentById(string departmentId)
        {
            return await CheckDepartmentIdIsValidAndReturnIt(departmentId);
        }

        public async Task CreateDepartment(CreateDepartmentRequest request)
        {
            if (DepartmentNameIsNotUnique(request.DepartmentName))
                throw new Exception("Department name is not unique");

            var department = _mapper.Map<Department>(request);
            await _departmentRepository.CreateDepartment(department);
        }

        public async Task UpdateDepartment(string departmentId, UpdateDepartmentRequest request)
        {
            await CheckDepartmentIdIsValidAndReturnIt(departmentId);
            if (DepartmentNameIsNotUnique(request.DepartmentName))
                throw new Exception("Department name is not unique");

            var department = _mapper.Map<Department>(request);
            await _departmentRepository.UpdateDepartment(departmentId, department);
        }

        public async Task DeleteDepartment(string departmentId)
        {
            await CheckDepartmentIdIsValidAndReturnIt(departmentId);
            await _departmentRepository.DeleteDepartment(departmentId);
        }

        private async Task<Department> CheckDepartmentIdIsValidAndReturnIt(string departmentId)
        {
            if (departmentId is null)
            {
                throw new BadHttpRequestException("Department Id is missing!");
            }
            var department = await GetDepartmentById(departmentId);

            if (department is null)
            {
                throw new KeyNotFoundException("The requested department does not exist");
            }
            return department;
        }

        private bool DepartmentNameIsNotUnique(string? name)
        {
            return GetAll().Result.Any(x => x.DepartmentName == name);
        }
    }
}

