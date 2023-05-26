using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("users_ref")]
public partial class UsersRef
{
    [Key]
    [Column("Op_No")]
    public long OpNo { get; set; }

    [Column("User_No")]
    public short UserNo { get; set; }

    [Column("User_Name")]
    [StringLength(200)]
    public string UserName { get; set; }

    [Column("User_Name_Latin")]
    [StringLength(200)]
    public string UserNameLatin { get; set; }

    [Column("User_Login_Name")]
    [StringLength(200)]
    public string UserLoginName { get; set; }

    [Column("User_Pass")]
    [StringLength(100)]
    public string UserPass { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    [StringLength(100)]
    public string Mobile { get; set; }

    [StringLength(200)]
    public string Address { get; set; }

    [StringLength(200)]
    public string Remarks { get; set; }

    [Column("Date_Open")]
    [StringLength(255)]
    public string DateOpen { get; set; }

    [Column("User_Cap")]
    public int? UserCap { get; set; }

    [Column("Arab_Mode")]
    public bool ArabMode { get; set; }

    public bool? Post { get; set; }

    [Column("All_Account")]
    public bool? AllAccount { get; set; }

    [Column("All_Cost")]
    public bool? AllCost { get; set; }

    [Column("All_Active")]
    public bool? AllActive { get; set; }

    [Column("All_Project")]
    public bool? AllProject { get; set; }

    public bool? Stop { get; set; }

    [Column("User_No_Created")]
    public int? UserNoCreated { get; set; }

    [Column("Origin_Date")]
    [MaxLength(6)]
    public DateTime? OriginDate { get; set; }

    [Column("User_No_Update")]
    public int? UserNoUpdate { get; set; }

    [Column("Update_Date")]
    [MaxLength(6)]
    public DateTime? UpdateDate { get; set; }

    [Column("PC_Name")]
    [StringLength(60)]
    public string PcName { get; set; }

    [Column("PC_User_Name")]
    [StringLength(60)]
    public string PcUserName { get; set; }

    [StringLength(2)]
    public string Status { get; set; }

    [Column("Status_Date")]
    [MaxLength(6)]
    public DateTime? StatusDate { get; set; }
}
