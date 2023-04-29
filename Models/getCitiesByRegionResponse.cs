using System;
namespace CharityApp.Models
{

	public class getCitiesByRegionResponse
	{
		public getCity cities { get; set; }
	}

	public class getCity
	{
        public int cityID { get; set; }
        public string cityName { get; set; }
    }
}