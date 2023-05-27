using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("banks_ref")]
public partial class BanksRef
{
    [Key]
    [Column("Op_No")]
    public long OpNo { get; set; }

    [Column("Bank_No")]
    public short BankNo { get; set; }

    [Column("Bank_Name")]
    [StringLength(100)]
    public string BankName { get; set; }

    [Column("Bank_Name_Latin")]
    [StringLength(100)]
    public string BankNameLatin { get; set; }

    [Column("Account_No")]
    [StringLength(16)]
    public string AccountNo { get; set; }

    [StringLength(200)]
    public string Address { get; set; }

    [Column("Contact_Name")]
    [StringLength(200)]
    public string ContactName { get; set; }

    [StringLength(200)]
    public string Remarks { get; set; }

    [StringLength(20)]
    public string Tel { get; set; }

    [StringLength(20)]
    public string Fax { get; set; }

    [Column("Date_Open")]
    [StringLength(255)]
    public string DateOpen { get; set; }

    public bool? Stop { get; set; }

    [Column("User_No_Created")]
    public short? UserNoCreated { get; set; }

    [Column("Origin_Date", TypeName = "datetime")]
    public DateTime? OriginDate { get; set; }

    [Column("User_No_Update")]
    public short? UserNoUpdate { get; set; }

    [Column("Update_Date", TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    [Column("PC_Name")]
    [StringLength(50)]
    public string PcName { get; set; }

    [Column("PC_User_Name")]
    [StringLength(50)]
    public string PcUserName { get; set; }

    [StringLength(2)]
    public string Status { get; set; }

    [Column("Status_Date", TypeName = "datetime")]
    public DateTime? StatusDate { get; set; }
}
