using System;
namespace CharityApp.Models
{
	public class getAllCountriesResponse
	{
        public countriesRes countries { get; set; }
	}

    public class countriesRes
    {
        public int countryID { get; set; }
        public string countryName { get; set; }
    }
}

