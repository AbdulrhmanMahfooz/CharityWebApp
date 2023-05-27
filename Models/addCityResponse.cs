using System;
namespace CharityApp.Models
{
	public class addCityResponse
	{
        public int cityId { get; set; }
        public int regionId { get; set; }
        public int countryId { get; set; }
        public string cityArName { get; set; }
        public string cityEnName { get; set; }
        public string cityCode { get; set; }
        public DateTime? createdAt { get; set; }
        public string accountNumber { get; set; }
        public string notes { get; set; }
        public bool isActivated { get; set; }
    }
}

