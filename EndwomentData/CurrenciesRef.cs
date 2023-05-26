using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("currencies_ref")]
public partial class CurrenciesRef
{
    [Key]
    [Column("Seq_Op")]
    public int SeqOp { get; set; }

    [Column("Currency_No")]
    public short CurrencyNo { get; set; }

    [Column("Currency_Name")]
    [StringLength(100)]
    public string CurrencyName { get; set; }

    [Column("Currency_Name_Latin")]
    [StringLength(100)]
    public string CurrencyNameLatin { get; set; }

    [Column("Currency_Short_Name")]
    [StringLength(20)]
    public string CurrencyShortName { get; set; }

    [Column("Currency_Short_Name_Latin")]
    [StringLength(20)]
    public string CurrencyShortNameLatin { get; set; }

    [Column("Fraction_Name")]
    [StringLength(20)]
    public string FractionName { get; set; }

    [Column("Fraction_Name_Latin")]
    [StringLength(20)]
    public string FractionNameLatin { get; set; }

    [Column("Date_Open")]
    [StringLength(255)]
    public string DateOpen { get; set; }

    public double? Rate { get; set; }

    [StringLength(200)]
    public string Remarks { get; set; }

    public bool? Stop { get; set; }

    [Column("User_No_Created")]
    public int? UserNoCreated { get; set; }

    [Column("Origin_Date", TypeName = "datetime")]
    public DateTime? OriginDate { get; set; }

    [Column("User_No_Update")]
    public int? UserNoUpdate { get; set; }

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
