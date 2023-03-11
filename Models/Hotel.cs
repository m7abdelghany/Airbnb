﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Models
{
    [Table("Hotel")]
    public partial class Hotel
    {
        public Hotel()
        {
            Bookings = new HashSet<Booking>();
            Images = new HashSet<Image>();
            Reviews = new HashSet<Review>();
            Rooms = new HashSet<Room>();
            Facilities = new HashSet<Facility>();
        }

        [Key]
        public int ID { get; set; }
        [StringLength(100)]
        
        public string Name { get; set; }
        public string Description { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Website { get; set; }
        public double? Rate { get; set; }
        public bool? Is_Available { get; set; }
        public int? City_Id { get; set; }
        public int? Category_Id { get; set; }
        [StringLength(450)]
        public string Hotel_admin { get; set; }
        public string HotelPayment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateFrom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTo { get; set; }
        [Column("Room-Price", TypeName = "decimal(18, 0)")]
        public decimal? Room_Price { get; set; }

        [ForeignKey("Category_Id")]
        [InverseProperty("Hotels")]
        public virtual Category Category { get; set; }
        [ForeignKey("City_Id")]
        [InverseProperty("Hotels")]
        public virtual City City { get; set; }
        [ForeignKey("Hotel_admin")]
        [InverseProperty("Hotels")]
        public virtual AspNetUser Hotel_adminNavigation { get; set; }
        [InverseProperty("Hotel")]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty("hotel")]
        public virtual ICollection<Image> Images { get; set; }
        [InverseProperty("Hotel")]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty("Hotel")]
        public virtual ICollection<Room> Rooms { get; set; }

        [ForeignKey("Hotel_Id")]
        [InverseProperty("Hotels")]
        public virtual ICollection<Facility> Facilities { get; set; }
    }
}