using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("voucher_endoment_header_ref")]
public partial class VoucherEndomentHeaderRef
{
    [Key]
    [Column("Op_No")]
    public long OpNo { get; set; }

    [Column("Branch_No")]
    public short BranchNo { get; set; }

    [Column("Voucher_No")]
    public int VoucherNo { get; set; }

    [Column("Pay_Type_No")]
    public short? PayTypeNo { get; set; }

    [Column("Date_Open")]
    [StringLength(255)]
    public string DateOpen { get; set; }

    [Column("Date_Hij")]
    [StringLength(10)]
    public string DateHij { get; set; }

    [Column("Cust_No")]
    [StringLength(20)]
    public string CustNo { get; set; }

    [Column("Ref_No")]
    [StringLength(100)]
    public string RefNo { get; set; }

    [Column("Foreign_Amt")]
    public double? ForeignAmt { get; set; }

    [Column("Currency_No")]
    public short? CurrencyNo { get; set; }

    public double? Rate { get; set; }

    public double? Amt { get; set; }

    [Column("Check_No")]
    [StringLength(30)]
    public string CheckNo { get; set; }

    [Column("Check_Date")]
    [StringLength(10)]
    public string CheckDate { get; set; }

    [Column("Bank_No")]
    public short? BankNo { get; set; }

    [StringLength(300)]
    public string Descriptions { get; set; }

    public bool? Post { get; set; }

    [Column("Post_No")]
    [StringLength(20)]
    public string PostNo { get; set; }

    [Column("Post_Date")]
    [StringLength(10)]
    public string PostDate { get; set; }

    [Column("Account_No_DB")]
    [StringLength(20)]
    public string AccountNoDb { get; set; }

    [Column("Cost_No_DB")]
    [StringLength(20)]
    public string CostNoDb { get; set; }

    [Column("Active_No_DB")]
    [StringLength(20)]
    public string ActiveNoDb { get; set; }

    [Column("User_No_Created")]
    public short? UserNoCreated { get; set; }

    [Column("Origin_Date", TypeName = "datetime")]
    public DateTime? OriginDate { get; set; }

    [Column("User_No_Update")]
    public short? UserNoUpdate { get; set; }

    [Column("Update_Date", TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public bool? RePrint { get; set; }

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
