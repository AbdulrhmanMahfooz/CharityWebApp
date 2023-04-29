using System;
namespace CharityApp.Models
{
	public class getDistrictsByCityResponse
	{
        public getDistrict districts { get; set; }
	}

    public class getDistrict
    {
        public int districtId { get; set; }
        public string districtName { get; set; }
    }
}

