using CharityApp.Models;
using CharityApp.testModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityApp.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly TestContext _testContex;
        public BranchController(TestContext testContext)
        {
            _testContex = testContext;
        }


        [HttpPost("get_branche")]
        public async Task<IActionResult> getBranches(getBranchRequest getBranch)
        {

            var branch = await _testContex.Branches
            .Where(x => x.BranchNo == getBranch.branchId)
            .FirstOrDefaultAsync();
            var testc = new BranchInfoResponse
            {
                branchId = branch.BranchNo,
                branchNo = branch.BranchNo,
                isBranchDeactivated =branch.Stop,
                branchOpenDate = branch.DateOpen,
                branchAdmin = branch.ContactName,
                branchArName = branch.BranchName,
                branchEnName = branch.BranchNameLatin,
                contactInfo = new ContactInfo
                {
                    telephone  =branch.Tel,
                    telephone_2 = branch.Tel1,
                    mobile = branch.Mobile,
                    mobile_2= branch.Mobile1,
                    fax = branch.Fax,
                    fax_2 = branch.Fax1,
                    email =  branch.Email,
                },

                branchAdrressInfo = new BranchAdrressInfo
                {
                    cityId = branch.CityNo,
                    districtId = branch.DistrictNo,
                     regionId = branch.RegionNo,    
                     countryId = branch.CountryNo,
                }
            };
            return Ok(testc);
         
        }

        [HttpPost("get_allBrachesByCompanyId")]
        public async Task<IActionResult> get_allBrachesByCompanyId(AllBranchesByCountryIdRequest countryid)
        {

            var branch = await _testContex.Branches
            .Where(x => x.CountryNo == countryid.CountryID)
            .ToListAsync();
            
            List<int> branchsIds = new List<int>();
            foreach (var id in branch)
            {
                branchsIds.Add(id.BranchNo);
            }

            var branchsIdResponse = new AllBranchesByCountryIdResponse
            {
                branchesId = branchsIds,
            };
            return Ok(branchsIdResponse);

        }



        [HttpPost("add_branche")]
        public async Task<IActionResult> addBranche(addBranchRequest add)
        {

            //if (add.branchId == 0)
            //{
            //    var addBranch = new TestDigitalData.Branch
            //    {
            //        BranchName = add.name,
            //        BranchNameLatin = add.nameEn,
            //        Address = add.address,
            //        ContactName = add.contact,
            //        DateOpen = add.Date_Open,
            //        CountryNo = (short)add.countryId,
            //        RegionNo = (short)add.regionId,
            //        CityNo = (short)add.cityId,
            //        DistrictNo = (short)add.districtId,
            //        StreetId = add.street,
            //        BuildingId = add.building,
            //        Remarks = add.Remarks,
            //        Email = add.email,
            //        Tel = add.telephone,

            //    };
            //    await _testContext.Branches.AddAsync(addBranch);
            //    await _testContext.SaveChangesAsync();
            //    return Ok(addBranch);
            //}
            //else
            //{
            //    var branch = await _testContext.Branches
            //        .Where(x => x.Id == add.branchId)
            //        .FirstOrDefaultAsync();
            //    branch.BranchName = add.name;
            //    branch.BranchNameLatin = add.nameEn;
            //    branch.Address = add.address;
            //    branch.ContactName = add.contact;
            //    branch.DateOpen = add.Date_Open;
            //    branch.CountryNo = (short)add.countryId;
            //    branch.RegionNo = (short)add.regionId;
            //    branch.CityNo = (short)add.cityId;
            //    branch.DistrictNo = (short)add.districtId;
            //    branch.StreetId = add.street;
            //    branch.BuildingId = add.building;
            //    branch.Remarks = add.Remarks;
            //    branch.Email = add.email;
            //    branch.Tel = add.telephone;

            //    await _testContext.SaveChangesAsync();
            //    return Ok(branch);
            //}
            return Ok();
        }
    }
    }

