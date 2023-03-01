namespace UserManagement.Repositories
{
    public class SiteRepository: ISiteRepository
    {
        private readonly IMongoCollection<SiteModel> _siteCollection;

        public SiteRepository(IOptions<UserManagementDatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _siteCollection = mongoDatabase.GetCollection<SiteModel>("Site");
        }
        public async Task<IEnumerable<SiteModel>> GetAll() =>
            await _siteCollection.Find(_ => true).ToListAsync();

        public async Task<SiteModel> GetSiteById(string siteId) =>
                await _siteCollection.Find(item => item.Id == siteId).FirstOrDefaultAsync();

        public async Task CreateSite(SiteModel site) =>
                await _siteCollection.InsertOneAsync(site);

        public async Task UpdateSite(string siteId, SiteModel site) =>
                await _siteCollection.ReplaceOneAsync<SiteModel>(item => item.Id == siteId, site);

        public async Task DeleteSite(string siteId) =>
                await _siteCollection.DeleteOneAsync<SiteModel>(item => item.Id == siteId);
    }
}

