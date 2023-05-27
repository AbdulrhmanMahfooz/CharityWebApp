using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityApp.Models.Countries
{
    public class add_edit_Counrty_Request
    {

       public int     countryId { get; set; }
       public string  countryCode {get; set; }
       public string  countryArName { get; set; }  
       public string  countryEnName { get; set; }     
       public string  createdAt { get; set; } 
       public string  notes { get; set; }
       public bool    isActivated { get; set; }              

    }
}
