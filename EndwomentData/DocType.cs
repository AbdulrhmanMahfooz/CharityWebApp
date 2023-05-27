using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("doc_types")]
public partial class DocType
{
    [Key]
    [Column("Type_Code")]
    [StringLength(2)]
    public string TypeCode { get; set; }

    [Column("Type_Name_Arb")]
    [StringLength(12)]
    public string TypeNameArb { get; set; }

    [Column("Type_Name_Eng")]
    [StringLength(12)]
    public string TypeNameEng { get; set; }

    [Column("Type_Short_Name")]
    [StringLength(6)]
    public string TypeShortName { get; set; }

    [Column("Type_Short_Eng")]
    [StringLength(6)]
    public string TypeShortEng { get; set; }

    [Column("Type_Counter")]
    [StringLength(10)]
    public string TypeCounter { get; set; }
}
