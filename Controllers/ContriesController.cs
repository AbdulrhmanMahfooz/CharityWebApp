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
using static System.Net.Mime.MediaTypeNames;

namespace CharityApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ContriesController : ControllerBase
	{
        private readonly TestContext _testContex;
        public ContriesController(TestContext testContext)
        {
            _testContex = testContext;
        }
        [HttpPost("get_All_Countries")]

        public async Task<ActionResult<IEnumerable<Country>>> GetObjects()
        {
            List<Country> countries = await _testContex.Countries.ToListAsync();
            List<getAllCountriesResponse> newcountries = countries.Select(Country => new getAllCountriesResponse
            {
                countries = new countriesRes
                {
                    countryID = Country.CountryNo,
                    countryName  = Country.CountryName
                }
                
            }).ToList();

            return Ok(newcountries);
        }
    }
}
