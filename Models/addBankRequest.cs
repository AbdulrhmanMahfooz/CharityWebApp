using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityApp.Models
{
    public class addBankRequest
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