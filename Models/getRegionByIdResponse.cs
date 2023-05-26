using System;
namespace CharityApp.Models
{
    public class getRegionByIdResponse
    {
        public short regionId { get; set; }
        public int countryId { get; set; }
        public string regionArName { get; set; }
        public string regionEnName { get; set; }
        public string regionCode { get; set; }
        public DateTime? createdAt { get; set; }
        public string notes { get; set; }
        public bool isActivated { get; set; }
    }
}
