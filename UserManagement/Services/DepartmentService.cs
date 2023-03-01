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
            return await CheckIfDepartmentIdIsValidAndReturnIt(departmentId);
        }
        public async Task CreateDepartment(CreateDepartmentRequest request)
        {
            if (CheckThatDepartmentNameIsUnique(request))
                throw new Exception("Department name is not unique");

            var department = _mapper.Map<Department>(request);
            await _departmentRepository.CreateDepartment(department);
        }

        public async Task UpdateDepartment(string departmentId, UpdateDepartmentRequest request)
        {
            await CheckIfDepartmentIdIsValidAndReturnIt(departmentId);
            if (CheckThatDepartmentNameIsUnique(request))
                throw new Exception("Department name is not unique");

            var department = _mapper.Map<Department>(request);
            await _departmentRepository.UpdateDepartment(departmentId, department);
        }

        public async Task DeleteDepartment(string departmentId)
        {
            await CheckIfDepartmentIdIsValidAndReturnIt(departmentId);
            await _departmentRepository.DeleteDepartment(departmentId);
        }

        private async Task<Department> CheckIfDepartmentIdIsValidAndReturnIt(string departmentId)
        {
            if (departmentId is null)
            {
                throw new BadHttpRequestException("Department Id is missing!");
            }
            var department = await _departmentRepository.GetDepartmentById(departmentId);

            if (department is null)
            {
                throw new KeyNotFoundException("The requested department does not exist");
            }
            return department;
        }

        private bool CheckThatDepartmentNameIsUnique(UpdateDepartmentRequest request)
        {
            return GetAll().Result.Any(x => x.DepartmentName == request.DepartmentName);
        }

        private bool CheckThatDepartmentNameIsUnique(CreateDepartmentRequest request)
        {
            return GetAll().Result.Any(x => x.DepartmentName == request.DepartmentName);
        }
    }
}

