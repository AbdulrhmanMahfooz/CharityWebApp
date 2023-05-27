using System;
namespace CharityApp.Models
{
    public class addBankResponse
    {
        public int bankId { get; set; }
        public int countryCode { get; set; }
        public int bankArName { get; set; }
        public int bankEnName { get; set; }
        public DateTime? createdAt { get; set; }
        public string notes { get; set; }
        public bool isActivated { get; set; }
    }
}

