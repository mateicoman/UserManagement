namespace UserManagement.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IMongoCollection<EmployeeModel> _departmentCollection;

        public EmployeeRepository(IOptions<UserManagementDatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _departmentCollection = mongoDatabase.GetCollection<EmployeeModel>("Employee");
        }
        public async Task<IEnumerable<EmployeeModel>> GetAll() =>
            await _departmentCollection.Find(_ => true).ToListAsync();

        public async Task<EmployeeModel> GetEmployeeById(string employeeId) =>
                await _departmentCollection.Find(item => item.Id == employeeId).FirstOrDefaultAsync();

        public async Task CreateEmployee(EmployeeModel employee) =>
                await _departmentCollection.InsertOneAsync(employee);

        public async Task UpdateEmployee(string employeeId, EmployeeModel employee) =>
                await _departmentCollection.ReplaceOneAsync<EmployeeModel>(item => item.Id == employeeId, employee);

        public async Task DeleteEmployee(string employeeId) =>
                await _departmentCollection.DeleteOneAsync<EmployeeModel>(item => item.Id == employeeId);
    }
}

