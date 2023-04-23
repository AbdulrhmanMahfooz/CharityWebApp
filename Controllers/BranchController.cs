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
        [HttpPost("get_branch")]
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
        public async Task<IActionResult> addBranch(addBranchRequest add)
        {
            if (add.branchId == 0)
            {
                var addBranch = new TestModels.Branch
                {
                    BranchNo=add.branchId,
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
                    Tel = add.telephone

                };
                var addBranchRef = new TestModels.BranchesRef
                {
                    BranchNo = add.branchId,
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
                branch.BranchName = branch.BranchName;
                branch.BranchNameLatin = branch.BranchNameLatin;
                branch.Address = branch.Address;
                branch.ContactName = branch.ContactName;
                branch.DateOpen = branch.DateOpen;
                //branch.CountryNo = (short)add.countryId;
                //branch.RegionNo = (short)add.regionId;
                //branch.CityNo = (short)add.cityId;
                //branch.DistrictNo = (short)add.districtId;
                branch.StreetId = branch.StreetId;
                branch.BuildingId = branch.BuildingId;
                branch.Remarks = branch.Remarks;
                branch.Email = branch.Email;
                branch.Tel = branch.Tel;


                var addBranchRef = new TestModels.BranchesRef
                {
                    BranchNo = branch.BranchNo,
                    BranchName = branch.BranchName,
                    BranchNameLatin = branch.BranchNameLatin,
                    Address = branch.Address,
                    ContactName = branch.ContactName,
                    DateOpen = branch.DateOpen,
                    //CountryNo = (short)branch.countryId,
                    //RegionNo = (short)branch.regionId,
                    //CityNo = (short)branch.cityId,
                    //DistrictNo = (short)branch.districtId,
                    StreetId = branch.StreetId,
                    BuildingId = branch.BuildingId,
                    Remarks = branch.Remarks,
                    Email = branch.Email,
                    Tel = branch.Tel,
                    ActionId = 2
                };


                await _testContex.BranchesRefs.AddAsync(addBranchRef);
                await _testContex.SaveChangesAsync();
                return Ok(branch);
            }

        }

        [HttpPost("delete_branch")]
        public async Task<IActionResult> deleteBranch(deleteBranchRequest ReBranch)
        {

            var branch = await _testContex.Branches
            .Where(x => x.BranchNo == ReBranch.branchId)
            .FirstOrDefaultAsync();


            var delete = new deleteBranchResponse
            {
                success = true
            };

            var addBranchRef = new TestModels.BranchesRef
            {
                BranchNo = branch.BranchNo,
                BranchName = branch.BranchName,
                BranchNameLatin = branch.BranchNameLatin,
                Address = branch.Address,
                ContactName = branch.ContactName,
                DateOpen = branch.DateOpen,
                //CountryNo = (short)branch.countryId,
                //RegionNo = (short)branch.regionId,
                //CityNo = (short)branch.cityId,
                //DistrictNo = (short)branch.districtId,
                StreetId = branch.StreetId,
                BuildingId = branch.BuildingId,
                Remarks = branch.Remarks,
                Email = branch.Email,
                Tel = branch.Tel,
       
                ActionId = 3
            };


            await _testContex.BranchesRefs.AddAsync(addBranchRef);
            //await _testContex.SaveChangesAsync();
            _testContex.Branches.Remove(branch);
            await _testContex.SaveChangesAsync();
            return Ok(true);

        }
    }
}