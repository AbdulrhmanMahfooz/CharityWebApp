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

    public class citiesController : ControllerBase
	{
        private readonly TestContext _testContex;
        public citiesController(TestContext testContext)
        {
            _testContex = testContext;
        }       
        [HttpPost("get_city_by_regionID")]

        public async Task<IActionResult> getCity(getCitiesByRegionRequest getCity)
        {
            List<City> cities = await _testContex.Cities.Where(x=> x.RegionNo == getCity.regionID).ToListAsync();

            List<getCitiesByRegionResponse> testc = cities.Select(city => new getCitiesByRegionResponse
            {
                cities = new getCity
                {
                    cityID = city.CityNo,
                    cityName = city.CityName
                }
            }).ToList();
            return Ok(testc);
        }
    }
}

