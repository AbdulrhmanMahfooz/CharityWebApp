using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CharityApp.TestDigitalData
{
    public partial class Branch
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("Branch_Name")]
        [StringLength(250)]
        public string BranchName { get; set; }
        [Column("Branch_Name_Latin")]
        [StringLength(250)]
        public string BranchNameLatin { get; set; }
        [Column("Contact_Name")]
        [StringLength(250)]
        public string ContactName { get; set; }
        [Column("Date_Open")]
        public DateTime? DateOpen { get; set; }
        [Column("Country_No")]
        public int? CountryNo { get; set; }
        [Column("Region_No")]
        public int? RegionNo { get; set; }
        [Column("City_No")]
        public int? CityNo { get; set; }
        [Column("District_No")]
        public int? DistrictNo { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [Column("Street_ID")]
        [StringLength(100)]
        public string StreetId { get; set; }
        [Column("Building_ID")]
        [StringLength(100)]
        public string BuildingId { get; set; }
        [StringLength(200)]
        public string Remarks { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Tel { get; set; }
    }
}
