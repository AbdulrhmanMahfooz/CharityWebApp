using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[PrimaryKey("BranchNo", "VoucherNo", "LineNo")]
[Table("voucher_endoment_lines")]
public partial class VoucherEndomentLine
{
    [Key]
    [Column("Branch_No")]
    public short BranchNo { get; set; }

    [Key]
    [Column("Voucher_No")]
    public int VoucherNo { get; set; }

    [Key]
    [Column("Line_No")]
    public short LineNo { get; set; }

    [Column("Pay_Type_No")]
    public short? PayTypeNo { get; set; }

    [Column("Date_Open")]
    [StringLength(255)]
    public string DateOpen { get; set; }

    [Column("Cust_No")]
    [StringLength(20)]
    public string CustNo { get; set; }

    [Column("ID_No")]
    public short? IdNo { get; set; }

    [Column("Account_No_CR")]
    [StringLength(20)]
    public string AccountNoCr { get; set; }

    public double? Amt { get; set; }
}
