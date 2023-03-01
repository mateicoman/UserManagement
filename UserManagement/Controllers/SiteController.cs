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
    public async Task<Site> GetSiteById(string siteId) =>
        await _siteService.GetSiteById(siteId);

    [HttpPost]
    public async Task<IActionResult> CreateSite(CreateSiteRequest request)
    {
        await _siteService.CreateSite(request);
        return Ok(new { message = "Site created" });
    }
    [HttpPut("{siteId}")]
    public async Task UpdateSite(string siteId, UpdateSiteRequest request) =>
            await _siteService.UpdateSite(siteId, request);

    [HttpDelete("{siteId}")]
    public async Task DeleteSite(string siteId) =>
            await _siteService.DeleteSite(siteId);
}

