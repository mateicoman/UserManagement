using UserManagement.Domain.DTOs.Employee;

namespace UserManagement.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IMongoCollection<EmployeeDto> _departmentCollection;

        public EmployeeRepository(IOptions<UserManagementDatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _departmentCollection = mongoDatabase.GetCollection<EmployeeDto>("Employee");
        }
        public async Task<IEnumerable<EmployeeDto>> GetAll() =>
            await _departmentCollection.Find(_ => true).ToListAsync();

        public async Task<EmployeeDto> GetEmployeeById(string employeeId) =>
                await _departmentCollection.Find(item => item.Id == employeeId).FirstOrDefaultAsync();

        public async Task CreateEmployee(EmployeeDto employee) =>
                await _departmentCollection.InsertOneAsync(employee);

        public async Task UpdateEmployee(string employeeId, EmployeeDto employee) =>
                await _departmentCollection.ReplaceOneAsync<EmployeeDto>(item => item.Id == employeeId, employee);

        public async Task DeleteEmployee(string employeeId) =>
                await _departmentCollection.DeleteOneAsync<EmployeeDto>(item => item.Id == employeeId);
    }
}

