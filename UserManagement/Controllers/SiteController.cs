using Microsoft.AspNetCore.Mvc;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class SiteController : ControllerBase
{
    private readonly ILogger<SiteController> _logger;
    private readonly ISiteService _siteService;

    public SiteController(ILogger<SiteController> logger, ISiteService siteService)
    {
        _logger = logger;
        _siteService = siteService;
    }

    [HttpGet]
    public async Task<IEnumerable<Site>> GetAll() =>
            await _siteService.GetAll();

    [HttpGet("{siteId}")]
    public async Task<ActionResult<Site>> GetSiteById(string siteId) =>
        await _siteService.GetSiteById(siteId);
    [HttpPost]
    public async Task<IActionResult> CreateSite(Site site)
    {
        await _siteService.CreateSite(site);
        return CreatedAtAction(nameof(GetSiteById), new { departmentId = site.Id }, site);
    }
    [HttpPut("{siteId}")]
    public async Task UpdateSite(string siteId, Site site) =>
            await _siteService.UpdateSite(siteId, site);

    [HttpDelete("{siteId}")]
    public async Task DeleteSite(string siteId) =>
            await _siteService.DeleteSite(siteId);
}

