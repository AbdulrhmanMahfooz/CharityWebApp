﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityApp.Models
{
    public class BranchInfoResponse
    {
        public int branchId { get; set; }
        public int branchNo { get; set; }  
        public bool? isBranchDeactivated { get; set; }
        public DateTime? branchOpenDate { get; set; }
        public string branchAdmin { get; set; }
        public string branchArName { get; set; }
        public string branchEnName { get; set; }
        public BranchAddressInfoRes branchAddressInfo { get; set; }
        public ContactInfoRes contactInfo { get; set; }


    }

    public class BranchAddressInfoRes
    {
        public int? countryId { get; set; }
        public int? cityId { get; set; }
        public int? regionId { get; set; }
        public int? districtId { get; set; }
        public string address { get; set; }
        public string street { get; set; }
        public string building { get; set; }
        public string postalCode { get; set; }
        public string postalBox { get; set; }
    }

    public class ContactInfoRes
    {
        public string telephone { get; set; }
        public string telephone_2 { get; set; }
        public string mobile { get; set; }
        public string mobile_2 { get; set; }
        public string fax { get; set; }
        public string fax_2 { get; set; }
        public string emailAddress { get; set; }
    }
}
