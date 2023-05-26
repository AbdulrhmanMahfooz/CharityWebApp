using CharityApp.Models;
using CharityApp.EndwomentData;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

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

        //Get District By ID
        [HttpPost("get_district_by_id")]

        public async Task<IActionResult> getDistrict(getDistrictByIdRequest getDistrict)
        {
            List<District> districts = await _endowmentContex.Districts.Where(x => x.DistrictNo == getDistrict.districtId).ToListAsync();

            List<getDistrictByIdResponse> testc = districts.Select(r => new getDistrictByIdResponse
            {

                districtId = r.DistrictNo,
                cityId = r.CityNo,
                regionId = r.RegionNo,
                countryId = r.CountryNo,
                isActivated = (bool) r.Stop,
                districtArName = r.DistrictName,
                districtEnName = r.DistrictNameLatin,
                createdAt = r.OriginDate,
                notes = r.Remarks
                
            }).ToList();
            return Ok(testc);
        }

        //Add District Endpoint
        [HttpPost("add_district")]
        public async Task<IActionResult> addDistrict(addDistrictRequest add)
        {
            if (add.districtId == 0)
            {
                var addDistrict = new EndwomentData.District
                {
                    DistrictNo = (short) add.districtId,
                    CityNo = (short) add.cityId,
                    RegionNo = (short) add.regionId,
                    CountryNo = (short) add.countryId,
                    DistrictName = add.districtArName,
                    DistrictNameLatin = add.districtEnName,
                    OriginDate = add.createdAt,
                    Remarks = add.notes,
                    Stop = add.isActivated

                };
                var addDistrictRef = new EndwomentData.DistrictsRef
                {
                    DistrictNo = (short)add.districtId,
                    CityNo = (short)add.cityId,
                    RegionNo = (short)add.regionId,
                    CountryNo = (short)add.countryId,
                    DistrictName = add.districtArName,
                    DistrictNameLatin = add.districtEnName,
                    OriginDate = add.createdAt,
                    Remarks = add.notes,
                    Stop = add.isActivated

                };

                await _endowmentContex.Districts.AddAsync(addDistrict);
                await _endowmentContex.DistrictsRefs.AddAsync(addDistrictRef);
                await _endowmentContex.SaveChangesAsync();

                return Ok(addDistrict);
            }
            else
            {
                var district = await _endowmentContex.Districts
                    .Where(x => x.DistrictNo == add.districtId)
                    .FirstOrDefaultAsync();


                district.DistrictNo = (short)add.districtId;
                district.CityNo = (short) add.cityId;
                district.RegionNo = (short) add.regionId;
                district.CountryNo = (short)add.countryId;
                district.DistrictName = add.districtArName;
                district.DistrictNameLatin = add.districtEnName;
                district.OriginDate = add.createdAt;
                district.Remarks = add.notes;
                district.Stop = add.isActivated;

                var addDistrictRef = new EndwomentData.DistrictsRef
                {

                    DistrictNo = district.districtId,
                    CityNo = district.cityId,
                    RegionNo = district.regionId,
                    CountryNo = district.countryId,
                    DistrictName = district.districtArName,
                    DistrictNameLatin = district.districtEnName,
                    OriginDate = district.createdAt,
                    Remarks = district.notes,
                    Stop = district.isActivated

                };


                await _endowmentContex.DistrictsRefs.AddAsync(addDistrictRef);
                await _endowmentContex.SaveChangesAsync();
                return Ok(district);
            }

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

        // Delete District Endpoint
        [HttpPost("delete_districts")]
        public async Task<IActionResult> deleteDistrict(deleteDistrictRequest DeDistrict)
        {

            var district = await _endowmentContex.Districts
            .Where(x => x.DistrictNo == DeDistrict.districtId)
            .FirstOrDefaultAsync();


            var delete = new deleteDistrictResponse
            {
                result = true
            };

            var addDistrictsRef = new EndwomentData.DistrictsRef
            {
                DistrictNo = district.DistrictNo,
                DistrictName = district.DistrictName,
                DistrictNameLatin = district.DistrictNameLatin,
                CityNo = district.CityNo,
                RegionNo = district.RegionNo,
                CountryNo = district.CountryNo,
                OriginDate = district.OriginDate,
                Remarks = district.Remarks,
                Stop = district.Stop
            };


            await _endowmentContex.DistrictsRefs.AddAsync(addDistrictsRef);
            //await _endowmentContex.SaveChangesAsync();
            _endowmentContex.Districts.Remove(district);
            await _endowmentContex.SaveChangesAsync();
            return Ok(true);

        }
    }
}