using System;
using CharityApp.Models;
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

    public class citiesController : ControllerBase
	{
        private readonly  EndowmentDbContext _endowmentContex;
        public citiesController( EndowmentDbContext  EndowmentDbContext)
        {
            _endowmentContex =  EndowmentDbContext;
        }


        //Get City By ID
        [HttpPost("get_city_by_id")]

        public async Task<IActionResult> getCity(getCityRequest getCity)
        {
            List<City> cities = await _endowmentContex.Cities.Where(x => x.CityNo == getCity.cityId).ToListAsync();

            List<getCityResponse> testc = cities.Select(r => new getCityResponse
            {
                cityId = r.CityNo,
                regionId = r.RegionNo,
                countryId = r.CountryNo,
                isActivated = (bool)r.Stop,
                cityArName = r.CityName,
                cityEnName = r.CityNameLatin,
                createdAt = r.OriginDate,
                notes = r.Remarks



            }).ToList();
            return Ok(testc);
        }


        [HttpPost("get_city_by_regionID")]

        public async Task<IActionResult> getCity(getCitiesByRegionRequest getCity)
        {
            List<City> cities = await _endowmentContex.Cities.Where(x=> x.RegionNo == getCity.regionID).ToListAsync();

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


        //Add City Endpoint
        [HttpPost("add_city")]
        public async Task<IActionResult> addCity(addCityRequest add)
        {
            if (add.cityId == 0)
            {
                var addCity = new EndwomentData.City
                {
                    CityNo = (short)add.cityId,
                    RegionNo = (short)add.regionId,
                    CountryNo = (short)add.countryId,
                    CityName = add.cityArName,
                    OriginDate = add.createdAt,
                    Remarks = add.notes,
                    Stop = add.isActivated

                };
                var addCityRef = new EndwomentData.CitiesRef
                {
                    CityNo = (short)add.cityId,
                    RegionNo = (short)add.regionId,
                    CountryNo = (short)add.countryId,
                    CityName = add.cityArName,
                    CityNameLatin = add.cityEnName,
                    OriginDate = add.createdAt,
                    Remarks = add.notes,
                    Stop = add.isActivated

                };

                await _endowmentContex.Cities.AddAsync(addCity);
                await _endowmentContex.CitiesRefs.AddAsync(addCityRef);
                await _endowmentContex.SaveChangesAsync();

                return Ok(addCity);
            }
            else
            {
                var city = await _endowmentContex.Cities
                    .Where(x => x.CityNo == add.cityId)
                    .FirstOrDefaultAsync();

                city.CityNo = (short)add.cityId;
                city.RegionNo = (short)add.regionId;
                city.CountryNo = (short)add.countryId;
                city.CityName = add.cityArName;
                city.CityNameLatin = add.cityEnName;
                city.OriginDate = add.createdAt;
                city.Remarks = add.notes;
                city.Stop = add.isActivated;

                var addCityRef = new EndwomentData.CitiesRef
                {

                    CityNo = city.CityNo,
                    RegionNo = city.RegionNo,
                    CountryNo = city.CountryNo,
                    CityName = city.CityName,
                    CityNameLatin = city.CityNameLatin,
                    OriginDate = city.OriginDate,
                    Remarks = city.Remarks,
                    Stop = city.Stop

                };


                await _endowmentContex.CitiesRefs.AddAsync(addCityRef);
                await _endowmentContex.SaveChangesAsync();
                return Ok(city);
            }

        }

        // Delete City Endpoint
        [HttpPost("delete_city")]
        public async Task<IActionResult> deleteCity(deleteCityRequest DeCity)
        {
            var city = await _endowmentContex.Cities
            .Where(x => x.CityNo == DeCity.cityId)
            .FirstOrDefaultAsync();
            var delete = new deleteCityResponse
            {
                result = true
            };

            var addCityRef = new EndwomentData.CitiesRef
            {
                CityNo = city.CityNo,
                RegionNo = city.RegionNo,
                CountryNo = city.CountryNo,
                CityName = city.CityName,
                CityNameLatin = city.CityNameLatin,
                OriginDate = city.OriginDate,
                Remarks = city.Remarks,
                Stop = city.Stop
            };

            await _endowmentContex.CitiesRefs.AddAsync(addCityRef);
            _endowmentContex.Cities.Remove(city);
            await _endowmentContex.SaveChangesAsync();
            return Ok(true);

        }
    }
}

