﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CharityApp.TestModels
{
    public partial class Region
    {
        public Region()
        {
            Branches = new HashSet<Branch>();
            Cities = new HashSet<City>();
        }

        public short RegionNo { get; set; }
        public string RegionName { get; set; }
        public string RegionNameLatin { get; set; }
        public string DateOpen { get; set; }
        public short CountryNo { get; set; }
        public string Remarks { get; set; }
        public bool? Stop { get; set; }
        public int? UserNoCreated { get; set; }
        public DateTime? OriginDate { get; set; }
        public int? UserNoUpdate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string PcName { get; set; }
        public string PcUserName { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }

        public virtual Country CountryNoNavigation { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
