using UserManagement.Domain.DTOs.Site;

namespace UserManagement.Domain.Interfaces.Repositories
{
    public interface ISiteRepository
    {
        Task<IEnumerable<SiteDto>> GetAll();
        Task<SiteDto> GetSiteById(string siteId);
        Task CreateSite(SiteDto site);
        Task UpdateSite(string siteId, SiteDto site);
        Task DeleteSite(string siteId);
    }
}

