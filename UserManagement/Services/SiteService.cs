using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class SiteService: ISiteService
    {
        private readonly ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }
        public async Task<IEnumerable<Site>> GetAll() =>
            await _siteRepository.GetAll();

        public async Task<Site> GetSiteById(string siteId)
        {
            if (siteId is null)
            {
                throw new BadHttpRequestException("Site Id is missing!");
            }
            var site = await _siteRepository.GetSiteById(siteId);

            return site;
        }
        public async Task CreateSite(Site site) =>
                await _siteRepository.CreateSite(site);

        public async Task UpdateSite(string siteId, Site site) =>
                await _siteRepository.UpdateSite(siteId, site);

        public async Task DeleteSite(string siteId) =>
                await _siteRepository.DeleteSite(siteId);
    }
}

