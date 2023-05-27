using CharityApp.EndwomentData;
using CharityApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System;

namespace CharityApp.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly EndowmentDbContext _endowmentContex;
        public BranchController(EndowmentDbContext EndowmentDbContext)
        {
            _endowmentContex = EndowmentDbContext;
        }


        [HttpPost("get_branche")]
        public async Task<IActionResult> getBranches(getBranchRequest getBranch)
        {

            var branch = await _endowmentContex.Branches
            .Where(x => x.BranchNo == getBranch.branchId)
            .FirstOrDefaultAsync();
            var testc = new BranchInfoResponse
            {
                branchId = branch.BranchNo,
                branchNo = branch.BranchNo,
                isBranchDeactivated =branch.Stop,
                
            branchOpenDate = DateTime.Parse(branch.DateOpen),
            branchAdmin = branch.ContactName,
                branchArName = branch.BranchName,
                branchEnName = branch.BranchNameLatin,
                contactInfo = new ContactInfoRes
                {
                    telephone  =branch.Tel,
                    telephone_2 = branch.Tel1,
                    mobile = branch.Mobile,
                    mobile_2= branch.Mobile1,
                    fax = branch.Fax,
                    fax_2 = branch.Fax1,
                    emailAddress =  branch.Email,
                },

                branchAddressInfo = new BranchAddressInfoRes
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

            var branch = await _endowmentContex.Branches
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
            if (add.branchId == 0)  // adding new Branch
            {
                var addBranch = new EndwomentData.Branch
                {
                    BranchNo= (short)add.branchNo,
                    DateOpen = add.branchOpenDate.ToString(),
                    BranchName = add.branchArName,
                    BranchNameLatin = add.branchEnName,
                    Stop = add.isBranchDeactivated,
      


                    Address = add.branchAddressInfo.address,
                    CountryNo = (short)add.branchAddressInfo.countryId,
                    RegionNo = (short)add.branchAddressInfo.regionId,
                    CityNo = (short)add.branchAddressInfo.cityId,
                    DistrictNo = (short)add.branchAddressInfo.districtId,
                    StreetId = add.branchAddressInfo.street,
                    BuildingId = add.branchAddressInfo.buildingNo,
                    ZipCode = add.branchAddressInfo.postalcode,
                    PoBox = add.branchAddressInfo.postalBox,


                    ContactName = add.branchAdmin,
                    Email = add.contactInfo.emailAddress,
                    Tel = add.contactInfo.phoneNo_1,
                    Tel1 = add.contactInfo.phoneNo_2,
                    Mobile = add.contactInfo.mobileNo_1,
                    Mobile1 = add.contactInfo.mobileNo_2,
                    Fax = add.contactInfo.faxNo_1,
                    Fax1 = add.contactInfo.faxNo_2
                };
                var addBranchRef = new EndwomentData.BranchesRef
                {
                    BranchNo = (short)add.branchNo,
                    DateOpen = add.branchOpenDate.ToString(),
                    BranchName = add.branchArName,
                    BranchNameLatin = add.branchEnName,
                    Address = add.branchAddressInfo.address,
                    //ContactName = add.contactInfo.,

                    CountryNo = (short)add.branchAddressInfo.countryId,
                    RegionNo = (short)add.branchAddressInfo.regionId,
                    CityNo = (short)add.branchAddressInfo.cityId,
                    DistrictNo = (short)add.branchAddressInfo.districtId,
                    StreetId = add.branchAddressInfo.street,
                    BuildingId = add.branchAddressInfo.buildingNo,
                    
                    Email = add.contactInfo.emailAddress,
                    Tel = add.contactInfo.phoneNo_1,
              
                };
                await _endowmentContex.Branches.AddAsync(addBranch);
                await _endowmentContex.BranchesRefs.AddAsync(addBranchRef);
                await _endowmentContex.SaveChangesAsync();


                var branch = addBranch;

                var testc = new BranchInfoResponse
                {
                    branchId = branch.BranchNo,
                    branchNo = branch.BranchNo,
                    isBranchDeactivated = branch.Stop,
                    branchOpenDate = DateTime.Parse(branch.DateOpen),
                    branchAdmin = branch.ContactName,
                    branchArName = branch.BranchName,
                    branchEnName = branch.BranchNameLatin,
                    contactInfo = new ContactInfoRes
                    {
                        telephone = branch.Tel,
                        telephone_2 = branch.Tel1,
                        mobile = branch.Mobile,
                        mobile_2 = branch.Mobile1,
                        fax = branch.Fax,
                        fax_2 = branch.Fax1,
                        emailAddress = branch.Email,
                    },

                    branchAddressInfo = new BranchAddressInfoRes
                    {
                        cityId = branch.CityNo,
                        districtId = branch.DistrictNo,
                        regionId = branch.RegionNo,
                        countryId = branch.CountryNo,
                    }
                };
                return Ok(testc);
            }
            else // editing Branch
            {
                var branch = await _endowmentContex.Branches
                    .Where(x => x.BranchNo == add.branchId)
                    .FirstOrDefaultAsync();


                  
                    branch.DateOpen = add.branchOpenDate.ToString();
                    branch.BranchName = add.branchArName;
                    branch.BranchNameLatin = add.branchEnName;
                    branch.Stop = add.isBranchDeactivated;
                    


                    branch.Address = add.branchAddressInfo.address;
                    branch.CountryNo = (short)add.branchAddressInfo.countryId;
                    branch.RegionNo = (short)add.branchAddressInfo.regionId;
                    branch.CityNo = (short)add.branchAddressInfo.cityId;
                    branch.DistrictNo = (short)add.branchAddressInfo.districtId;
                    branch.StreetId = add.branchAddressInfo.street;
                    branch.BuildingId = add.branchAddressInfo.buildingNo;
                    branch.ZipCode = add.branchAddressInfo.postalcode;
                    branch.PoBox = add.branchAddressInfo.postalBox;


                    branch.ContactName = add.branchAdmin;
                    branch.Email = add.contactInfo.emailAddress;
                    branch.Tel = add.contactInfo.phoneNo_1;
                    branch.Tel1 = add.contactInfo.phoneNo_2;
                    branch.Mobile = add.contactInfo.mobileNo_1;
                    branch.Mobile1 = add.contactInfo.mobileNo_2;
                    branch.Fax = add.contactInfo.faxNo_1;
                    branch.Fax1 = add.contactInfo.faxNo_2;





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


                var addBranchRef = new EndwomentData.BranchesRef
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
                    
                };


                var testc = new BranchInfoResponse
                {
                    branchId = branch.BranchNo,
                    branchNo = branch.BranchNo,
                    isBranchDeactivated = branch.Stop,
                    branchOpenDate = DateTime.Parse(branch.DateOpen),
                    branchAdmin = branch.ContactName,
                    branchArName = branch.BranchName,
                    branchEnName = branch.BranchNameLatin,
                    contactInfo = new ContactInfoRes
                    {
                        telephone = branch.Tel,
                        telephone_2 = branch.Tel1,
                        mobile = branch.Mobile,
                        mobile_2 = branch.Mobile1,
                        fax = branch.Fax,
                        fax_2 = branch.Fax1,
                        emailAddress = branch.Email,
                    },

                    branchAddressInfo = new BranchAddressInfoRes
                    {
                        cityId = branch.CityNo,
                        districtId = branch.DistrictNo,
                        regionId = branch.RegionNo,
                        countryId = branch.CountryNo,
                    }
                };


                _endowmentContex.Branches.Update(branch);

                await _endowmentContex.BranchesRefs.AddAsync(addBranchRef);
                await _endowmentContex.SaveChangesAsync();
                return Ok(testc);
            }

        }

        [HttpPost("delete_branch")]
        public async Task<IActionResult> deleteBranch(deleteBranchRequest ReBranch)
        {

            var branch = await _endowmentContex.Branches
            .Where(x => x.BranchNo == ReBranch.branchId)
            .FirstOrDefaultAsync();


            var delete = new deleteBranchResponse
            {
                success = true
            };

            var addBranchRef = new EndwomentData.BranchesRef
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
                Tel = branch.Tel
            };


            await _endowmentContex.BranchesRefs.AddAsync(addBranchRef);
            //await _endowmentContex.SaveChangesAsync();
            _endowmentContex.Branches.Remove(branch);
            await _endowmentContex.SaveChangesAsync();
            return Ok(true);

        }
    }
}