﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Models
{
    [Table("Invoice")]
    public partial class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public int? Guest_Id { get; set; }
        public int? Booking_Id { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime? IssueDate { get; set; }
        public int? PaymentType_Id { get; set; }

        [ForeignKey("Booking_Id")]
        [InverseProperty("Invoices")]
        public virtual Booking Booking { get; set; }
        [ForeignKey("PaymentType_Id")]
        [InverseProperty("Invoices")]
        public virtual PaymentType PaymentType { get; set; }
    }
}