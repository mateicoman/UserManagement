namespace UserManagement.Repositories
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly IMongoCollection<Department> _departmentCollection;

        public DepartmentRepository(IOptions<UserManagementDatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _departmentCollection = mongoDatabase.GetCollection<Department>("Department");
        }
        public async Task<IEnumerable<Department>> GetAll() =>
            await _departmentCollection.Find(_ => true).ToListAsync();

        public async Task<Department> GetDepartmentById(string departmentId) =>
                await _departmentCollection.Find(item => item.Id == departmentId).FirstOrDefaultAsync();

        public async Task CreateDepartment(Department department) =>
                await _departmentCollection.InsertOneAsync(department);

        public async Task UpdateDepartment(string departmentId, Department department) =>
                await _departmentCollection.ReplaceOneAsync<Department>(item => item.Id == departmentId, department);

        public async Task DeleteDepartment(string departmentId) =>
                await _departmentCollection.DeleteOneAsync<Department>(item => item.Id == departmentId);
    }
}

