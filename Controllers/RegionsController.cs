using System;
using CharityApp.Models;
using CharityApp.TestModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Xml.Linq;

namespace CharityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegionsController : ControllerBase
    {
        private readonly TestContext _testContex;
        public RegionsController(TestContext testContext)
        {
            _testContex = testContext;
        }
        [HttpPost("get_region_by_countryID")]

        public async Task<IActionResult> getRegion(getRegionsByCountriesRequest getRegion)
        {
            List<Region> regions = await _testContex.Regions.Where(x => x.CountryNo == getRegion.CountryID).ToListAsync();

            List<getRegionsByCountriesResponse> testc = regions.Select(r => new getRegionsByCountriesResponse
            {
                regions = new getRegion
                {
                    RegionID = r.RegionNo,
                    RegionName = r.RegionName
                }
            }).ToList();
            return Ok(testc);
        }
    }
}

