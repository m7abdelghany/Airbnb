﻿using Airbnb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Airbnbfinal.Models
{
    public class AppUser: IdentityUser
    {
        [Required, MaxLength(255)]
        public string FirstName { get; set; }

        [Required, MaxLength(255)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int GovID { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; } = DateTime.Now;

        // Address info
        [StringLength(20, MinimumLength = 1)]
        public string BuildingNo { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Street { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Zipcode { get; set; }

        [ForeignKey(nameof(City))]
        public int? CityId { get; set; }
        public virtual City City { get; set; }

        // Relations
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Hotel> Hotels { get; set; }

      
    }

    public enum Gender
    {
        Male,
        Female
    }
}

