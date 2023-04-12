using CharityApp.Models;
using CharityApp.TestModels;
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
            var testc = new addBranchResponse
            {
                building = branch.BuildingId,
                email = branch.Email,
                name = branch.BranchName,
                street = branch.StreetId,


            };
            return Ok(testc);

        }
        [HttpPost("add_branch")]
        public async Task<IActionResult> addBranche(addBranchRequest add)
        {

            if (add.branchId == 0)
            {
                var addBranch = new TestModels.Branch

                {
                    //BranchNo=105,
                    BranchName = add.name,
                    BranchNameLatin = add.nameEn,
                    Address = add.address,
                    ContactName = add.contact,
                    DateOpen = add.Date_Open,
                    //CountryNo = (short)add.countryId,
                    //RegionNo = (short)add.regionId,
                    //CityNo = (short)add.cityId,
                    //DistrictNo = (short)add.districtId,
                    StreetId = add.street,
                    BuildingId = add.building,
                    Remarks = add.Remarks,
                    Email = add.email,
                    //Tel = add.telephone,

                };
                var addBranchRef = new TestModels.BranchesRef
                {
                    BranchNo = 5,
                    BranchName = add.name,
                    BranchNameLatin = add.nameEn,
                    Address = add.address,
                    ContactName = add.contact,
                    DateOpen = add.Date_Open,
                    //CountryNo = (short)add.countryId,
                    //RegionNo = (short)add.regionId,
                    //CityNo = (short)add.cityId,
                    //DistrictNo = (short)add.districtId,
                    StreetId = add.street,
                    BuildingId = add.building,
                    Remarks = add.Remarks,
                    Email = add.email,
                    Tel = add.telephone,
                    ActionId = 1
                };
                await _testContex.Branches.AddAsync(addBranch);
                await _testContex.BranchesRefs.AddAsync(addBranchRef);
                await _testContex.SaveChangesAsync();

                return Ok(addBranch);
            }
            else
            {
                var branch = await _testContex.Branches
                    .Where(x => x.BranchNo == add.branchId)
                    .FirstOrDefaultAsync();
                branch.BranchName = add.name;
                branch.BranchNameLatin = add.nameEn;
                branch.Address = add.address;
                branch.ContactName = add.contact;
                branch.DateOpen = add.Date_Open;
                //branch.CountryNo = (short)add.countryId;
                //branch.RegionNo = (short)add.regionId;
                //branch.CityNo = (short)add.cityId;
                //branch.DistrictNo = (short)add.districtId;
                branch.StreetId = add.street;
                branch.BuildingId = add.building;
                branch.Remarks = add.Remarks;
                branch.Email = add.email;
                branch.Tel = add.telephone;


                var addBranchRef = new TestModels.BranchesRef
                {
                    BranchNo = (short)add.branchId,
                    BranchName = add.name,
                    BranchNameLatin = add.nameEn,
                    Address = add.address,
                    ContactName = add.contact,
                    DateOpen = add.Date_Open,
                    //CountryNo = (short)add.countryId,
                    //RegionNo = (short)add.regionId,
                    //CityNo = (short)add.cityId,
                    //DistrictNo = (short)add.districtId,
                    StreetId = add.street,
                    BuildingId = add.building,
                    Remarks = add.Remarks,
                    Email = add.email,
                    Tel = add.telephone,
                    ActionId = 2
                };


                await _testContex.BranchesRefs.AddAsync(addBranchRef);
                await _testContex.SaveChangesAsync();
                return Ok(branch);
            }

        }
    }
}