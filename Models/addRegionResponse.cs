using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityApp.Models
{
    public class addRegionResponse
    {
        public int regionId { get; set; }
        public int countryId { get; set; }
        public string regionArName { get; set; }
        public string regionEnName { get; set; }
        public string regionCode { get; set; }
        public DateTime? createdAt { get; set; }
        public string notes { get; set; }
        public bool isActivated { get; set; }

    }

}