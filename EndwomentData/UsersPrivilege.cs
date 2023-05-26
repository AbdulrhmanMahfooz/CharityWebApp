using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("users_privileges")]
public partial class UsersPrivilege
{
    [Column("Company_No")]
    public short CompanyNo { get; set; }

    [Column("User_No")]
    public short UserNo { get; set; }

    [Column("Page_No")]
    public int PageNo { get; set; }

    public bool Adding { get; set; }

    public bool Modifying { get; set; }

    public bool Deleting { get; set; }

    public bool Displaying { get; set; }

    [Key]
    [Column("index")]
    public int Index { get; set; }
}
