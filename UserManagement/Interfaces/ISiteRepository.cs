using System;
using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface ISiteRepository
    {
        Task<IEnumerable<SiteModel>> GetAll();
        Task<SiteModel> GetSiteById(string siteId);
        Task CreateSite(SiteModel site);
        Task UpdateSite(string siteId, SiteModel site);
        Task DeleteSite(string siteId);
    }
}

