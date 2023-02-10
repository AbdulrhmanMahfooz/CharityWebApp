using CharityApp.Models;

using CharityApp.TestDigitalData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CharityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly TestContext _testContext;
        public BranchController(TestContext testContext)
        {
            _testContext = testContext;
        }
        [HttpPost("get_branche")]
        public async Task<IActionResult> getBranches(getBranchRequest getBranch)
        {
            
            var branch = await _testContext.Branches
            .Where(x => x.Id == getBranch.branchId)
            .FirstOrDefaultAsync();
            var testc = new addBranchResponse
            {
                building = branch.BuildingId,
                email = branch.Email,
                name=branch.BranchName,
                street = branch.StreetId,
              
              
            };
            return Ok(testc);
        }
        [HttpPost("add_branche")]
        public async Task<IActionResult> addBranche(addBranchRequest add)
        {

            if (add.branchId == 0)
            {
                var addBranch = new TestDigitalData.Branch
                {
                    BranchName = add.name,
                    BranchNameLatin = add.nameEn,
                    Address = add.address,
                    ContactName = add.contact,
                    DateOpen = add.Date_Open,
                    CountryNo = (short)add.countryId,
                    RegionNo = (short)add.regionId,
                    CityNo = (short)add.cityId,
                    DistrictNo = (short)add.districtId,
                    StreetId = add.street,
                    BuildingId = add.building,
                    Remarks = add.Remarks,
                    Email = add.email,
                    Tel = add.telephone,
                  
                };
                await _testContext.Branches.AddAsync(addBranch);
                await _testContext.SaveChangesAsync();
                return Ok(addBranch);
            }
            else
            {
                var branch = await _testContext.Branches
                    .Where(x => x.Id == add.branchId)
                    .FirstOrDefaultAsync();
                branch.BranchName = add.name;
                branch.BranchNameLatin = add.nameEn;
                branch.Address = add.address;
                branch.ContactName = add.contact;
                branch.DateOpen = add.Date_Open;
                branch.CountryNo = (short)add.countryId;
                branch.RegionNo = (short)add.regionId;
                branch.CityNo = (short)add.cityId;
                branch.DistrictNo = (short)add.districtId;
                branch.StreetId = add.street;
                branch.BuildingId = add.building;
                branch.Remarks = add.Remarks;
                branch.Email = add.email;
                branch.Tel = add.telephone;
              
                await _testContext.SaveChangesAsync();
                return Ok(branch);
            }

        }
    }
    }

