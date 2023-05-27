using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CharityApp.EndwomentData;

[Table("payment_type")]
public partial class PaymentType
{
    [Key]
    [Column("Payment_No")]
    public short PaymentNo { get; set; }

    [Column("Payment_Name")]
    [StringLength(20)]
    public string PaymentName { get; set; }

    [Column("Payment_Name_Latin")]
    [StringLength(20)]
    public string PaymentNameLatin { get; set; }
}
