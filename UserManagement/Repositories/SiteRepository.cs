using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class SiteRepository: ISiteRepository
    {
        private readonly IMongoCollection<Site> _siteCollection;

        public SiteRepository(IOptions<UserManagementDatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _siteCollection = mongoDatabase.GetCollection<Site>("Site");
        }
        public async Task<IEnumerable<Site>> GetAll() =>
            await _siteCollection.Find(_ => true).ToListAsync();

        public async Task<Site> GetSiteById(string siteId) =>
                await _siteCollection.Find(item => item.Id == siteId).FirstOrDefaultAsync();

        public async Task CreateSite(Site site) =>
                await _siteCollection.InsertOneAsync(site);

        public async Task UpdateSite(string siteId, Site site) =>
                await _siteCollection.ReplaceOneAsync<Site>(item => item.Id == siteId, site);

        public async Task DeleteSite(string siteId) =>
                await _siteCollection.DeleteOneAsync<Site>(item => item.Id == siteId);
    }
}

