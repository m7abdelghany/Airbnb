﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Airbnb.Models
{
    public partial class Graduationproject1Context : DbContext
    {
        public Graduationproject1Context()
        {
        }

        public Graduationproject1Context(DbContextOptions<Graduationproject1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Graduationproject1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Gender).HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).ValueGeneratedNever();

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Hotel_Id)
                    .HasConstraintName("FK_Bookings_Hotel");

                entity.HasMany(d => d.Rooms)
                    .WithMany(p => p.Bookings)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoomBooked",
                        l => l.HasOne<Room>().WithMany().HasForeignKey("Room_Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RoomBooked_Room"),
                        r => r.HasOne<Booking>().WithMany().HasForeignKey("Booking_Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RoomBooked_Bookings"),
                        j =>
                        {
                            j.HasKey("Booking_Id", "Room_Id");

                            j.ToTable("RoomBooked");
                        });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.Property(e => e.FacilityId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.Category_Id)
                    .HasConstraintName("FK_Hotel_Category");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.City_Id)
                    .HasConstraintName("FK_Hotel_City");

                entity.HasOne(d => d.Hotel_adminNavigation)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.Hotel_admin)
                    .HasConstraintName("FK_Hotel_AspNetUsers");

                entity.HasMany(d => d.Facilities)
                    .WithMany(p => p.Hotels)
                    .UsingEntity<Dictionary<string, object>>(
                        "HotelFacility",
                        l => l.HasOne<Facility>().WithMany().HasForeignKey("Facility_Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_HotelFacility_Facilities"),
                        r => r.HasOne<Hotel>().WithMany().HasForeignKey("Hotel_Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_HotelFacility_Hotel"),
                        j =>
                        {
                            j.HasKey("Hotel_Id", "Facility_Id");

                            j.ToTable("HotelFacility");
                        });
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.ImgId)
                    .HasName("PK_Table_1");

                entity.HasOne(d => d.hotel)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.hotel_id)
                    .HasConstraintName("FK_Images_Hotel");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceId).ValueGeneratedNever();

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Booking_Id)
                    .HasConstraintName("FK_Invoice_Bookings");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PaymentType_Id)
                    .HasConstraintName("FK_Invoice_PaymentType");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.PaymentID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Hotel_Id)
                    .HasConstraintName("FK_Reviews_Hotel");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.User_Id)
                    .HasConstraintName("FK_Reviews_AspNetUsers");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.Hotel_Id)
                    .HasConstraintName("FK_Room_Hotel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}