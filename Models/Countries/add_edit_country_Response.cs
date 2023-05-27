namespace CharityApp.Models.Countries
{
    public class add_edit_country_Response
    {
        public Data data { get; set; } 
    }
    public class Data
    {
        public int countryId { get; set; }
        public string countryCode { get; set; }
        public string countryArName { get; set; }
        public string countryEnName { get; set; }
        public string createdAt { get; set; }
        public string notes { get; set; }
        public bool isActivated { get; set; }

    }
}
