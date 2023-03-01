﻿namespace UserManagement.Services
{
    public class SiteService: ISiteService
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IMapper _mapper;

        public SiteService(ISiteRepository siteRepository, IMapper mapper)
        {
            _siteRepository = siteRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SiteModel>> GetAll() =>
            await _siteRepository.GetAll();

        public async Task<SiteModel> GetSiteById(string siteId)
        {
            return await CheckSiteIdIsValidAndReturnIt(siteId);
        }

        public async Task CreateSite(CreateSiteRequest request)
        {
            if (SiteNameIsNotUnique(request.SiteName))
                throw new Exception("Site name is not unique");

            var site = _mapper.Map<SiteModel>(request);
            await _siteRepository.CreateSite(site);
        }

        public async Task UpdateSite(string siteId, UpdateSiteRequest request)
        {
            await CheckSiteIdIsValidAndReturnIt(siteId);
            if (SiteNameIsNotUnique(request.SiteName))
                throw new Exception("Site name is not unique");

            var site = _mapper.Map<SiteModel>(request);
            await _siteRepository.UpdateSite(siteId, site);
        }

        public async Task DeleteSite(string siteId)
        {
            await CheckSiteIdIsValidAndReturnIt(siteId);
            await _siteRepository.DeleteSite(siteId);
        }

        private async Task<SiteModel> CheckSiteIdIsValidAndReturnIt(string siteId)
        {
            if (siteId is null)
            {
                throw new BadHttpRequestException("Site Id is missing!");
            }
            var site = await GetSiteById(siteId);

            if (site is null)
            {
                throw new KeyNotFoundException("The requested site does not exist");
            }
            return site;
        }

        private bool SiteNameIsNotUnique(string? name)
        {
            return GetAll().Result.Any(x => x.SiteName == name);
        }
    }
}

