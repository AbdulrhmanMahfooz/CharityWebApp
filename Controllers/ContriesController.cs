using System;
using CharityApp.Models;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CharityApp.Models.Countries;
using System.Data.Entity;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using CharityApp.EndwomentData;
using System.Diagnostics;

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



        // adding and eediting Country EndPoint
        [HttpPost("add_edit_country")]
        public async Task<IActionResult> add_edit_country(add_edit_Counrty_Request addEditRequest)
        {
            
            
            if (addEditRequest.countryId!=0) 
            {
                // edit 
                var country = await _endowmentContex.Countries
                    .Where(x => x.CountryNo == addEditRequest.countryId)
                    .FirstOrDefaultAsync();


                country.CountryName = addEditRequest.countryArName;
                country.CountryNameLatin = addEditRequest.countryEnName;
                country.DateOpen = addEditRequest.createdAt;
                country.Remarks = addEditRequest.notes;
                country.Stop = addEditRequest.isActivated;

                _endowmentContex.Countries.Update(country);
            }
            else
            {
                // add 
                var AddEditCountry = new EndwomentData.Country
                {
                    CountryName=addEditRequest.countryArName,
                    CountryNameLatin=addEditRequest.countryEnName,
                    DateOpen= addEditRequest.createdAt,
                    Stop= addEditRequest.isActivated,
                    Remarks= addEditRequest.notes
                };


        

                await _endowmentContex.Countries.AddAsync(AddEditCountry);
              

            };

            var AddEditCountryRef = new EndwomentData.CountriesRef
            {
                CountryNo = (short)addEditRequest.countryId,
                CountryName = addEditRequest.countryArName,
                CountryNameLatin = addEditRequest.countryEnName,
                DateOpen = addEditRequest.createdAt,
                Stop = addEditRequest.isActivated,
                Remarks = addEditRequest.notes
            };
            await _endowmentContex.CountriesRefs.AddAsync(AddEditCountryRef);


            await _endowmentContex.SaveChangesAsync();

            var Res = new add_edit_country_Response
            {
                data = new Data
                {
                    countryCode = addEditRequest.countryCode,
                    countryArName = addEditRequest.countryArName,
                    countryEnName = addEditRequest.countryEnName,
                    createdAt = addEditRequest.createdAt,
                    notes = addEditRequest.notes,
                    isActivated = addEditRequest.isActivated,
                }
            };
            return Ok(Res);

        }


        // Delete Country
        [HttpPost("Delete_Country")]
        public async Task<IActionResult> Delete_Coutry(Delete_Country delete_Country)
        {


            var country = await _endowmentContex.Countries
                   .Where(x => x.CountryNo == delete_Country.countryId)
                   .FirstOrDefaultAsync();
        if (country != null)
            {
                _endowmentContex.Countries.Remove(country);
                await _endowmentContex.SaveChangesAsync();
                return Ok(true);
            }
        else
            {
                return Ok(false);
            }
        }


        // Get Country BY ID 
        [HttpPost("Get_Country_BY_ID")]
        public async Task<IActionResult> Get_Country_By_ID (Delete_Country country_req)  // Delete_Country class is Used becaue it has same request attribute
        {


            var country = await _endowmentContex.Countries
                   .Where(x => x.CountryNo == country_req.countryId)
                   .FirstOrDefaultAsync();
            if (country != null)
            {

                var Res = new add_edit_country_Response
                {
                    data = new Data
                    {
                        countryCode = country.CountryNo.ToString(),
                        countryArName = country.CountryName,
                        countryEnName = country.CountryNameLatin,
                        createdAt = country.DateOpen,
                        notes = country.Remarks,
                        isActivated = (bool) country.Stop,
                    }
                };
                return Ok(Res);
            }
            else
            {
                return Ok(false);
            }




        }



    }





}


