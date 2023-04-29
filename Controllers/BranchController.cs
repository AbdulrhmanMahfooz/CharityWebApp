using CharityApp.Models;
using CharityApp.TestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
                //branchAddressInfo = new BranchAddressInfo
                //{
                //    building = branch.BuildingId
                //}                
                //email = branch.Email,
                //name = branch.BranchName,
                //street = branch.StreetId,


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
                    DateOpen = add.Date_Open,
                    BranchName = add.name,
                    BranchNameLatin = add.nameEn,
                    Stop = add.stop,
                    Remarks = add.Remarks,


                    Address = add.branchAddressInfo.address,
                    CountryNo = (short)add.branchAddressInfo.countryId,
                    RegionNo = (short)add.branchAddressInfo.regionId,
                    CityNo = (short)add.branchAddressInfo.cityId,
                    DistrictNo = (short)add.branchAddressInfo.districtId,
                    StreetId = add.branchAddressInfo.street,
                    BuildingId = add.branchAddressInfo.building,
                    ZipCode = add.branchAddressInfo.zipCode,
                    PoBox = add.branchAddressInfo.poBox,


                    ContactName = add.contactInfo.contact,
                    Email = add.contactInfo.email,
                    Tel = add.contactInfo.telephone,
                    Tel1 = add.contactInfo.telephone_2,
                    Mobile = add.contactInfo.mobile,
                    Mobile1 = add.contactInfo.mobile_2,
                    Fax = add.contactInfo.fax,
                    Fax1 = add.contactInfo.fax_2
                };
                var addBranchRef = new TestModels.BranchesRef
                {
                    BranchNo = add.branchId,
                    DateOpen = add.Date_Open,
                    BranchName = add.name,
                    BranchNameLatin = add.nameEn,
                    Address = add.branchAddressInfo.address,
                    //ContactName = add.contactInfo.,

                    CountryNo = (short)add.branchAddressInfo.countryId,
                    RegionNo = (short)add.branchAddressInfo.regionId,
                    CityNo = (short)add.branchAddressInfo.cityId,
                    DistrictNo = (short)add.branchAddressInfo.districtId,
                    StreetId = add.branchAddressInfo.street,
                    BuildingId = add.branchAddressInfo.building,
                    Remarks = add.Remarks,
                    Email = add.contactInfo.email,
                    Tel = add.contactInfo.telephone,
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


                    branch.BranchNo = add.branchId;
                    branch.DateOpen = add.Date_Open;
                    branch.BranchName = add.name;
                    branch.BranchNameLatin = add.nameEn;
                    branch.Stop = add.stop;
                    branch.Remarks = add.Remarks;


                    branch.Address = add.branchAddressInfo.address;
                    branch.CountryNo = (short)add.branchAddressInfo.countryId;
                    branch.RegionNo = (short)add.branchAddressInfo.regionId;
                    branch.CityNo = (short)add.branchAddressInfo.cityId;
                    branch.DistrictNo = (short)add.branchAddressInfo.districtId;
                    branch.StreetId = add.branchAddressInfo.street;
                    branch.BuildingId = add.branchAddressInfo.building;
                    branch.ZipCode = add.branchAddressInfo.zipCode;
                    branch.PoBox = add.branchAddressInfo.poBox;


                    branch.ContactName = add.contactInfo.contact;
                    branch.Email = add.contactInfo.email;
                    branch.Tel = add.contactInfo.telephone;
                    branch.Tel1 = add.contactInfo.telephone_2;
                    branch.Mobile = add.contactInfo.mobile;
                    branch.Mobile1 = add.contactInfo.mobile_2;
                    branch.Fax = add.contactInfo.fax;
                    branch.Fax1 = add.contactInfo.fax_2;





                //branch.BranchName = branch.BranchName;
                //branch.BranchNameLatin = branch.BranchNameLatin;
                //branch.Address = branch.Address;
                //branch.ContactName = branch.ContactName;
                //branch.DateOpen = branch.DateOpen;
                ////branch.CountryNo = (short)add.countryId;
                ////branch.RegionNo = (short)add.regionId;
                ////branch.CityNo = (short)add.cityId;
                ////branch.DistrictNo = (short)add.districtId;
                //branch.StreetId = branch.StreetId;
                //branch.BuildingId = branch.BuildingId;
                //branch.Remarks = branch.Remarks;
                //branch.Email = branch.Email;
                //branch.Tel = branch.Tel;


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