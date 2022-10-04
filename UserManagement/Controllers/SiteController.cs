using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    public class SiteController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<Site>> Get() =>
            throw new NotImplementedException();

        [HttpGet("{id}")]
        public Task<Site> GetSiteById(int id) =>
            throw new NotImplementedException();

        [HttpPost]
        public void CreateSite(Site site) =>
            throw new NotImplementedException();

        [HttpPut("{id}")]
        public void UpdateSite(int id, Site site) =>
            throw new NotImplementedException();

        [HttpDelete("{id}")]
        public void DeleteSite(int id) =>
            throw new NotImplementedException();
    }
}

