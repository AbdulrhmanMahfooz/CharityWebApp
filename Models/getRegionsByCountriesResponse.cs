using System;
namespace CharityApp.Models
{
	public class getRegionsByCountriesResponse
	{
		public getRegion regions { get; set; }
	}

	public class getRegion
	{
        public int RegionID { get; set; }
        public string RegionName { get; set; }
    }
}

