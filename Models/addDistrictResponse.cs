using System;
namespace CharityApp.Models
{
	public class addDistrictResponse
	{
        public int districtId { get; set; }
        public int cityId { get; set; }
        public int regionId { get; set; }
        public int countryId { get; set; }
        public string districtArName { get; set; }
        public string districtEnName { get; set; }
        public string disctrictCode { get; set; }
        public DateTime? createdAt { get; set; }
        public string notes { get; set; }
        public bool isActivated { get; set; }
    }
}

