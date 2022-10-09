using System;
using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface ISiteRepository
    {
        Task<IEnumerable<Site>> GetAll();
        Task<Site> GetSiteById(string siteId);
        Task CreateSite(Site site);
        Task UpdateSite(string siteId, Site site);
        Task DeleteSite(string siteId);
    }
}

