﻿using UserManagement.Domain.DTOs.Department;

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

        public async Task<IEnumerable<DepartmentDto>> GetAll() =>
            await _departmentRepository.GetAll();

        public async Task<DepartmentDto> GetDepartmentById(string departmentId)
        {
            return await CheckDepartmentIdIsValidAndReturnIt(departmentId);
        }

        public async Task CreateDepartment(DepartmentPostDto request)
        {
            if (DepartmentNameIsNotUnique(request.DepartmentName))
                throw new Exception("Department name is not unique");

            var department = _mapper.Map<DepartmentDto>(request);
            await _departmentRepository.CreateDepartment(department);
        }

        public async Task UpdateDepartment(string departmentId, DepartmentPutDto request)
        {
            await CheckDepartmentIdIsValidAndReturnIt(departmentId);
            if (DepartmentNameIsNotUnique(request.DepartmentName))
                throw new Exception("Department name is not unique");

            var department = _mapper.Map<DepartmentDto>(request);
            await _departmentRepository.UpdateDepartment(departmentId, department);
        }

        public async Task DeleteDepartment(string departmentId)
        {
            await CheckDepartmentIdIsValidAndReturnIt(departmentId);
            await _departmentRepository.DeleteDepartment(departmentId);
        }

        private async Task<DepartmentDto> CheckDepartmentIdIsValidAndReturnIt(string departmentId)
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

        private bool DepartmentNameIsNotUnique(string? name)
        {
            return GetAll().Result.Any(x => x.DepartmentName == name);
        }
    }
}

