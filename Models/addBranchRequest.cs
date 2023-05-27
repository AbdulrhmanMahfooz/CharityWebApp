using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityApp.Models
{

    public class addBranchRequest
    {
        public int branchId { get; set; }
        public int branchNo { get; set; }
        public bool? isBranchDeactivated { get; set; }
        public DateTime? branchOpenDate { get; set; }
        public string branchAdmin { get; set; }
        public string branchArName { get; set; }
        public string branchEnName { get; set; }


        public BranchAddressInfoReq branchAddressInfo { get; set; }
        public ContactInfoReq contactInfo { get; set; }
    }

    public class BranchAddressInfoReq
    {
        public int countryId { get; set; }
        public int cityId { get; set; }
        public int regionId { get; set; }
        public int districtId { get; set; }
        public string address { get; set; }
        public string street { get; set; }
        public string buildingNo { get; set; }
        public string postalcode { get; set; }
        public string postalBox { get; set; }
    }

    public class ContactInfoReq
    {
        
        public string phoneNo_1 { get; set; }
        public string phoneNo_2 { get; set; }
        public string mobileNo_1 { get; set; }
        public string mobileNo_2 { get; set; }
        public string faxNo_1 { get; set; }
        public string faxNo_2 { get; set; }
        public string emailAddress { get; set; }

    }
}
