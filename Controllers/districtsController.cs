﻿using System;
using CharityApp.Models;
//using CharityApp.TestModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Xml.Linq;
using CharityApp.EndwomentData;

namespace CharityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class districtsController : ControllerBase
    {
        private readonly EndowmentDbContext _endowmentContex;
        public districtsController(EndowmentDbContext EndowmentDbContext)
        {
            _endowmentContex = EndowmentDbContext;
        }
        [HttpPost("get_district_by_cityID")]

        public async Task<IActionResult> getDistrict(getDistrictsByCityRequest getDistrict)
        {
            List<District> districts = await _endowmentContex.Districts.Where(x => x.CityNo == getDistrict.CityID).ToListAsync();

            List<getDistrictsByCityResponse> testc = districts.Select(district => new getDistrictsByCityResponse
            {
                districts = new getDistrict
                {
                    districtId = district.DistrictNo,
                    districtName = district.DistrictName
                }
            }).ToList();
            return Ok(testc);

        }
    }
}