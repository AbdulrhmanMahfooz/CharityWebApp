using System;
using CharityApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
//using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Xml.Linq;
using CharityApp.EndwomentData;

namespace CharityApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class RegionsController : ControllerBase
    {
        private readonly EndowmentDbContext _endowmentContex;
        public RegionsController(EndowmentDbContext EndowmentDbContext)
        {
            _endowmentContex = EndowmentDbContext;
        }


        //Get Region By ID
        [HttpPost("get_region_by_id")]

        public async Task<IActionResult> getRegion(getRegionByIdRequest getRegion)
        {
            List<Region> regions = await _endowmentContex.Regions.Where(x => x.RegionNo == getRegion.regionId).ToListAsync();

            List<getRegionByIdResponse> testc = regions.Select(r => new getRegionByIdResponse
            {

                regionId = r.RegionNo,
                countryId = r.CountryNo,
                createdAt = r.OriginDate,
                notes = r.Remarks,
                regionArName = r.RegionName,
                regionEnName = r.RegionNameLatin,
                isActivated = (bool) r.Stop
            }).ToList();
            return Ok(testc);
        }

        //Get Region By Country ID
        [HttpPost("get_region_by_countryID")]

        public async Task<IActionResult> getRegion(getRegionsByCountriesRequest getRegion)
        {
            List<Region> regions = await _endowmentContex.Regions.Where(x => x.CountryNo == getRegion.CountryID).ToListAsync();

            List<getRegionsByCountriesResponse> testc = regions.Select(r => new getRegionsByCountriesResponse
            {
                regions = new getRegion
                {
                    RegionID = r.RegionNo,
                    RegionName = r.RegionName,
                    
                    
                }
            }).ToList();
            return Ok(testc);
        }



        //Add Region Endpoint
        [HttpPost("add_region")]
        public async Task<IActionResult> addRegion(addRegionRequest add)
        {
            if (add.regionId == 0)
            {
                var addRegion = new EndwomentData.Region
                {
                    RegionNo = (short) add.regionId,
                    CountryNo = (short) add.countryId,
                    RegionName = add.regionArName,
                    RegionNameLatin = add.regionEnName,
                    OriginDate = add.createdAt,
                    Remarks = add.notes,
                    Stop = add.isActivated
                    

                };
                var addRegionRef = new EndwomentData.RegionsRef
                {
                    RegionNo = (short)add.regionId,
                    CountryNo = (short)add.countryId,
                    RegionName = add.regionArName,
                    RegionNameLatin = add.regionEnName,
                    OriginDate = add.createdAt,
                    Remarks = add.notes,
                    Stop = add.isActivated


                };

                await _endowmentContex.Regions.AddAsync(addRegion);
                await _endowmentContex.RegionsRefs.AddAsync(addRegionRef);
                await _endowmentContex.SaveChangesAsync();

                return Ok(addRegion);
            }
            else
            {
                var region = await _endowmentContex.Regions
                    .Where(x => x.RegionNo == add.regionId)
                    .FirstOrDefaultAsync();


                region.RegionNo = (short) add.regionId;
                region.RegionName = add.regionArName;
                region.RegionNameLatin = add.regionEnName;
                region.CountryNo = (short) add.countryId;
                region.OriginDate = add.createdAt;
                region.Remarks = add.notes;
                region.Stop = add.isActivated;
                



                var addRegionRef = new EndwomentData.RegionsRef
                {
                    RegionNo = region.RegionNo,
                    RegionName = region.RegionName,
                    RegionNameLatin = region.RegionNameLatin,
                    CountryNo = region.CountryNo,
                    OriginDate = region.OriginDate,
                    Remarks = region.Remarks,
                    Stop = region.Stop
                };


                await _endowmentContex.RegionsRefs.AddAsync(addRegionRef);
                await _endowmentContex.SaveChangesAsync();
                return Ok(region);
            }

        }


        // Delete Region Endpoint
        [HttpPost("delete_region")]
        public async Task<IActionResult> deleteRegion(deleteRegionRequest DeRegion)
        {

            var region = await _endowmentContex.Regions
            .Where(x => x.RegionNo == DeRegion.regionId)
            .FirstOrDefaultAsync();


            var delete = new deleteRegionResponse
            {
                result = true
            };

            var addRegionsRef = new EndwomentData.RegionsRef
            {
                RegionNo = region.RegionNo,
                RegionName = region.RegionName,
                RegionNameLatin = region.RegionNameLatin,
                CountryNo = region.CountryNo,
                OriginDate = region.OriginDate,
                Remarks = region.Remarks,
                Stop = region.Stop

            };


            await _endowmentContex.RegionsRefs.AddAsync(addRegionsRef);
            //await _endowmentContex.SaveChangesAsync();
            _endowmentContex.Regions.Remove(region);
            await _endowmentContex.SaveChangesAsync();
            return Ok(true);

        }
    }
}

