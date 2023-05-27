using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("countries")]
public partial class Country
{
    [Key]
    [Column("Country_No")]
    public short CountryNo { get; set; }

    [Column("Country_Name")]
    [StringLength(100)]
    public string CountryName { get; set; }

    [Column("Country_Name_Latin")]
    [StringLength(100)]
    public string CountryNameLatin { get; set; }

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

    [InverseProperty("CountryNoNavigation")]
    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
