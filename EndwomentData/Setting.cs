using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("setting")]
public partial class Setting
{
    [Key]
    [Column("Company_No")]
    [StringLength(10)]
    public string CompanyNo { get; set; }

    [Column("Doc_Seq")]
    public short? DocSeq { get; set; }

    [Column("Doc_Other_Seq")]
    public short? DocOtherSeq { get; set; }

    [Column("Date_Calendar")]
    [StringLength(1)]
    public string DateCalendar { get; set; }

    [StringLength(16)]
    public string Assets { get; set; }

    [StringLength(16)]
    public string Deductions { get; set; }

    [StringLength(16)]
    public string Profit { get; set; }

    [Column("Year_Profit")]
    [StringLength(16)]
    public string YearProfit { get; set; }

    [Column("Income_No")]
    [StringLength(16)]
    public string IncomeNo { get; set; }

    [Column("Costs_No")]
    [StringLength(16)]
    public string CostsNo { get; set; }

    [Column("Expenses_No")]
    [StringLength(16)]
    public string ExpensesNo { get; set; }

    [Column("Purchase_No")]
    [StringLength(16)]
    public string PurchaseNo { get; set; }

    [Column("Op_Expneses_No")]
    [StringLength(16)]
    public string OpExpnesesNo { get; set; }

    [Column("First_Stock_No")]
    [StringLength(16)]
    public string FirstStockNo { get; set; }

    [Column("Last_Stock_No")]
    [StringLength(16)]
    public string LastStockNo { get; set; }

    [Column("Year_Start")]
    [StringLength(10)]
    public string YearStart { get; set; }

    [Column("Year_End")]
    [StringLength(10)]
    public string YearEnd { get; set; }

    [Column("Cash_No")]
    [StringLength(10)]
    public string CashNo { get; set; }

    [Column("Bank_No")]
    [StringLength(10)]
    public string BankNo { get; set; }

    [Column("Approve_Journal")]
    public bool? ApproveJournal { get; set; }

    [Column("Approve_Payment")]
    public bool? ApprovePayment { get; set; }

    [Column("Approve_Receipt")]
    public bool? ApproveReceipt { get; set; }

    [Column("Sales_No")]
    [StringLength(10)]
    public string SalesNo { get; set; }

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
