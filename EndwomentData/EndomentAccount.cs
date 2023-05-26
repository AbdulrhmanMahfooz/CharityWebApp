using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("endoment_accounts")]
public partial class EndomentAccount
{
    [Key]
    [Column("ID_NO")]
    public int IdNo { get; set; }

    [Required]
    [Column("Account_No")]
    [StringLength(20)]
    public string AccountNo { get; set; }

    [Column("Account_Name")]
    [StringLength(200)]
    public string AccountName { get; set; }

    [Column("Account_Name_Latin")]
    [StringLength(200)]
    public string AccountNameLatin { get; set; }

    [Column("Date_Open")]
    [StringLength(255)]
    public string DateOpen { get; set; }

    [StringLength(200)]
    public string Remarks { get; set; }

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
