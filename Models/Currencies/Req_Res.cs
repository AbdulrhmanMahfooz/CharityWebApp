namespace CharityApp.Models.Currencies
{


    public class add_edit_currency_Req
    {
        
        public int    currenyId { get; set; }  
        public string currencyArName { get; set; } 
        public string currencyEnName { get; set; }
        public string createdAt { get; set; } 
        public double convertionRate { get; set; }
        public string arCode    {get;set; }   
        public string enCode { get; set; }   
        public string notes { get; set; }    
        public bool   isActivate {get; set; }  
        
    }


    public class add_edit_currencey_Res
    {
        public Data data { get; set; }  
    }
    public class Data
    {
        public int currenyId { get; set; }
        public string currencyArName { get; set; }
        public string currencyEnName { get; set; }
        public string createdAt { get; set; }
        public double convertionRate { get; set; }
        public string arCode { get; set; }
        public string enCode { get; set; }
        public string notes { get; set; }
        public bool isActivate { get; set; }
    }

    public class delete_currencey_Req
    {
        public int currenyId { get; set; }
    }

    public class get_currencey_Res
    {
        public int currenyId { get; set; }
    }
}
