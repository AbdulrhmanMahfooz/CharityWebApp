using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("customers")]
public partial class Customer
{
    [Key]
    [Column("Cust_No")]
    [StringLength(20)]
    public string CustNo { get; set; }

    [Column("Cust_Name")]
    [StringLength(400)]
    public string CustName { get; set; }

    [Column("Cust_Name_Latin")]
    [StringLength(400)]
    public string CustNameLatin { get; set; }

    [Column("Commerical_Name")]
    [StringLength(400)]
    public string CommericalName { get; set; }

    [Column("Contact_Name")]
    [StringLength(400)]
    public string ContactName { get; set; }

    [StringLength(400)]
    public string Address { get; set; }

    [Column("ID_No")]
    [StringLength(30)]
    public string IdNo { get; set; }

    public bool? Local { get; set; }

    [Column("Class_No")]
    public short? ClassNo { get; set; }

    [Column("Group_No")]
    [StringLength(10)]
    public string GroupNo { get; set; }

    [Column("Country_No")]
    public short CountryNo { get; set; }

    [Column("Region_No")]
    public short RegionNo { get; set; }

    [Column("City_No")]
    public short CityNo { get; set; }

    [Column("District_No")]
    public short DistrictNo { get; set; }

    [Column("Date_Open")]
    [StringLength(255)]
    public string DateOpen { get; set; }

    [Column("Date_Hij")]
    [StringLength(10)]
    public string DateHij { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    [StringLength(30)]
    public string Tel { get; set; }

    [StringLength(30)]
    public string Mobile { get; set; }

    [Column("Mobile_1")]
    [StringLength(30)]
    public string Mobile1 { get; set; }

    [StringLength(30)]
    public string Fax { get; set; }

    [Column("Po_Box")]
    [StringLength(30)]
    public string PoBox { get; set; }

    [Column("Zip_Code")]
    [StringLength(30)]
    public string ZipCode { get; set; }

    [Column("Vat_Reg")]
    [StringLength(30)]
    public string VatReg { get; set; }

    [Column("IBAN_No")]
    [StringLength(60)]
    public string IbanNo { get; set; }

    [StringLength(400)]
    public string Remarks { get; set; }

    [Column("Credit_Limit")]
    public double? CreditLimit { get; set; }

    public double? Credit { get; set; }

    public double? Debit { get; set; }

    public double? Balance { get; set; }

    [Column("Free_Limit")]
    public short? FreeLimit { get; set; }

    public bool? Stop { get; set; }

    [Column("Account_No")]
    [StringLength(20)]
    public string AccountNo { get; set; }

    [Column("Cost_No")]
    [StringLength(20)]
    public string CostNo { get; set; }

    [Column("Active_NO")]
    [StringLength(20)]
    public string ActiveNo { get; set; }

    [Column("Project_NO")]
    [StringLength(20)]
    public string ProjectNo { get; set; }

    [Column("User_No_Created")]
    public int? UserNoCreated { get; set; }

    [Column("Origin_Date", TypeName = "datetime")]
    public DateTime? OriginDate { get; set; }

    [Column("User_No_Update")]
    public int? UserNoUpdate { get; set; }

    [Column("Update_Date", TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    [Column("PC_Name")]
    [StringLength(100)]
    public string PcName { get; set; }

    [Column("PC_User_Name")]
    [StringLength(100)]
    public string PcUserName { get; set; }

    [StringLength(2)]
    public string Status { get; set; }

    [Column("Status_Date", TypeName = "datetime")]
    public DateTime? StatusDate { get; set; }
}
