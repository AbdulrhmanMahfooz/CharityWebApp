using System;
using CharityApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using CharityApp.EndwomentData;

namespace CharityApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ContriesController : ControllerBase
	{
        private readonly EndowmentDbContext _endowmentContex;
        public ContriesController(EndowmentDbContext EndowmentDbContext)
        {
            _endowmentContex = EndowmentDbContext;
        }
        [HttpPost("get_All_Countries")]

        public async Task<ActionResult<IEnumerable<Country>>> GetObjects()
        {
            List<Country> countries = await _endowmentContex.Countries.ToListAsync();
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
