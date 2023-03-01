using System;
using UserManagement.Models;
using UserManagement.Models.Requests;

namespace UserManagement.Interfaces
{
    public interface ISiteService
    {
        Task<IEnumerable<SiteModel>> GetAll();
        Task<SiteModel> GetSiteById(string siteId);
        Task CreateSite(CreateSiteRequest site);
        Task UpdateSite(string siteId, UpdateSiteRequest site);
        Task DeleteSite(string siteId);
    }
}

