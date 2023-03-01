namespace UserManagement.Repositories
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private readonly IMongoCollection<DepartmentModel> _departmentCollection;

        public DepartmentRepository(IOptions<UserManagementDatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _departmentCollection = mongoDatabase.GetCollection<DepartmentModel>("Department");
        }
        public async Task<IEnumerable<DepartmentModel>> GetAll() =>
            await _departmentCollection.Find(_ => true).ToListAsync();

        public async Task<DepartmentModel> GetDepartmentById(string departmentId) =>
                await _departmentCollection.Find(item => item.Id == departmentId).FirstOrDefaultAsync();

        public async Task CreateDepartment(DepartmentModel department) =>
                await _departmentCollection.InsertOneAsync(department);

        public async Task UpdateDepartment(string departmentId, DepartmentModel department) =>
                await _departmentCollection.ReplaceOneAsync<DepartmentModel>(item => item.Id == departmentId, department);

        public async Task DeleteDepartment(string departmentId) =>
                await _departmentCollection.DeleteOneAsync<DepartmentModel>(item => item.Id == departmentId);
    }
}

