using System;
namespace CharityApp.Models
{
    public class getDistrictByIdRequest
    {
        public short districtId { get; set; }
        public int cityId { get; set; }
        public int regionId { get; set; }
        public int countryId { get; set; }
        public string districtArName { get; set; }
        public string districtEnName { get; set; }
        public string districtCode { get; set; }
        public string createdAt { get; set; }
        public string notes { get; set; }
        public string regionCode { get; set; }
        public bool isActivated { get; set; }

    }
}
