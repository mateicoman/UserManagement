using UserManagement.Domain.DTOs.Site;

namespace UserManagement.Repositories
{
    public class SiteRepository: ISiteRepository
    {
        private readonly IMongoCollection<SiteDto> _siteCollection;

        public SiteRepository(IOptions<UserManagementDatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _siteCollection = mongoDatabase.GetCollection<SiteDto>("Site");
        }
        public async Task<IEnumerable<SiteDto>> GetAll() =>
            await _siteCollection.Find(_ => true).ToListAsync();

        public async Task<SiteDto> GetSiteById(string siteId) =>
                await _siteCollection.Find(item => item.Id == siteId).FirstOrDefaultAsync();

        public async Task CreateSite(SiteDto site) =>
                await _siteCollection.InsertOneAsync(site);

        public async Task UpdateSite(string siteId, SiteDto site) =>
                await _siteCollection.ReplaceOneAsync<SiteDto>(item => item.Id == siteId, site);

        public async Task DeleteSite(string siteId) =>
                await _siteCollection.DeleteOneAsync<SiteDto>(item => item.Id == siteId);
    }
}

