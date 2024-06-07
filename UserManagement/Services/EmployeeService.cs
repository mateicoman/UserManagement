using UserManagement.Domain.DTOs.Employee;

namespace UserManagement.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAll() =>
            await _employeeRepository.GetAll();

        public async Task<EmployeeDto> GetEmployeeById(string employeeId)
        {
            return await CheckEmployeeIdIsValidAndReturnEmployee(employeeId);
        }
        public async Task CreateEmployee(EmployeePostDto request)
        {
            if (EmployeeUsernameIsNotUnique(request.Username))
                throw new Exception("Employee username is not unique");

            if (EmployeeEmailIsNotUnique(request.Email))
                throw new Exception("Employee email is not unique");

            var employee = _mapper.Map<EmployeeDto>(request);
            await _employeeRepository.CreateEmployee(employee);
        }

        public async Task UpdateEmployee(string employeeId, EmployeePutDto request)
        {
            await CheckEmployeeIdIsValidAndReturnEmployee(employeeId);
            if (EmployeeUsernameIsNotUnique(employeeId))
                throw new Exception("Employee username is not unique");

            if (EmployeeEmailIsNotUnique(request.Email))
                throw new Exception("Employee email is not unique");

            var employee = _mapper.Map<EmployeeDto>(request);
            await _employeeRepository.UpdateEmployee(employeeId, employee);
        }

        public async Task DeleteEmployee(string employeeId)
        {
            await CheckEmployeeIdIsValidAndReturnEmployee(employeeId);
            await _employeeRepository.DeleteEmployee(employeeId);
        }
                

        private async Task<EmployeeDto> CheckEmployeeIdIsValidAndReturnEmployee(string employeeId)
        {
            if (employeeId is null)
                throw new BadHttpRequestException("Employee Id is missing");
            var employee = await GetEmployeeById(employeeId);

            if (employee is null)
                throw new KeyNotFoundException("The requested employee does not exist");

            return employee;
        }

        private bool EmployeeUsernameIsNotUnique(string? username)
        {
            return GetAll().Result.Any(x => x.Username == username);
        }

        private bool EmployeeEmailIsNotUnique(string? email)
        {
            return GetAll().Result.Any(x => x.Email == email);
        }
    }
}

