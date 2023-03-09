﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Models
{
    [Index("NormalizedEmail", Name = "EmailIndex")]
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            Hotels = new HashSet<Hotel>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        public string Id { get; set; }
        [StringLength(256)]
        public string UserName { get; set; }
        [StringLength(256)]
        public string NormalizedUserName { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        [StringLength(256)]
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; }
        [Required]
        public bool? Gender { get; set; }
        public string LastName { get; set; }

        [InverseProperty("Hotel_adminNavigation")]
        public virtual ICollection<Hotel> Hotels { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}