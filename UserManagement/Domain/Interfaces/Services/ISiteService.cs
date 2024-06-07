using UserManagement.Domain.DTOs.Site;

namespace UserManagement.Domain.Interfaces.Services
{
    public interface ISiteService
    {
        Task<IEnumerable<SiteDto>> GetAll();
        Task<SiteDto> GetSiteById(string siteId);
        Task CreateSite(SitePostDto site);
        Task UpdateSite(string siteId, SitePutDto site);
        Task DeleteSite(string siteId);
    }
}

