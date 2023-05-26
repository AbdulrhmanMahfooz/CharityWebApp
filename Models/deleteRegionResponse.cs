using System;
namespace CharityApp.Models
{
    public class deleteRegionResponse
    {
        public int regionId { get; set; }
        public string name { get; set; }
        public string nameEn { get; set; }
        public DateTime Date_Open { get; set; }
        public short countryId { get; set; }
        public string Remarks { get; set; }
        public bool? stop { get; set; }
        public int? userCreated { get; set; }
        public DateTime originDate { get; set; }
        public int? userUdated { get; set; }
        public DateTime? updateDate { get; set; }
        public string PC { get; set; }
        public string PcUser { get; set; }
        public string status { get; set; }
        public DateTime? statusDate { get; set; }

        public bool? result { get; set; }
    }
}
