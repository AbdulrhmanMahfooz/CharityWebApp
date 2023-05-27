using System;
namespace CharityApp.Models
{
	public class getBankByIdResponse
	{
        public int bankId { get; set; }
        public int countryCode { get; set; }
        public string bankArName { get; set; }
        public string bankEnName { get; set; }
        public DateTime? createdAt { get; set; }
        public string notes { get; set; }
        public bool isActivated { get; set; }
    }
}

