using UserManagement.Domain.DTOs.Department;

namespace UserManagement.Repositories
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly IMongoCollection<DepartmentDto> _departmentCollection;

        public DepartmentRepository(IOptions<UserManagementDatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _departmentCollection = mongoDatabase.GetCollection<DepartmentDto>("Department");
        }
        public async Task<IEnumerable<DepartmentDto>> GetAll() =>
            await _departmentCollection.Find(_ => true).ToListAsync();

        public async Task<DepartmentDto> GetDepartmentById(string departmentId) =>
                await _departmentCollection.Find(item => item.Id == departmentId).FirstOrDefaultAsync();

        public async Task CreateDepartment(DepartmentDto department) =>
                await _departmentCollection.InsertOneAsync(department);

        public async Task UpdateDepartment(string departmentId, DepartmentDto department) =>
                await _departmentCollection.ReplaceOneAsync<DepartmentDto>(item => item.Id == departmentId, department);

        public async Task DeleteDepartment(string departmentId) =>
                await _departmentCollection.DeleteOneAsync<DepartmentDto>(item => item.Id == departmentId);
    }
}

