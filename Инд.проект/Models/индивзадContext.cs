using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Инд.проект.Models
{
    public partial class индивзадContext : DbContext
    {
        public индивзадContext()
        {
        }

        public индивзадContext(DbContextOptions<индивзадContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amenity> Amenities { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarRentalAgency> CarRentalAgencies { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PrivateFace> PrivateFaces { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.HasKey(e => e.AmenitiesCode)
                    .HasName("PK__Amenitie__FD700949F98B21A4");

                entity.Property(e => e.AmenitiesCode).HasColumnName("Amenities_code");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingCode)
                    .HasName("PK__Booking__83B0C0EEFA5F4A1C");

                entity.ToTable("Booking");

                entity.Property(e => e.BookingCode).HasColumnName("Booking_code");

                entity.Property(e => e.AmenitiesCode).HasColumnName("Amenities_code");

                entity.Property(e => e.BookingStartDate)
                    .HasColumnType("date")
                    .HasColumnName("Booking_start_date");

                entity.Property(e => e.BookingStatus).HasColumnName("Booking_status");

                entity.Property(e => e.CarCode).HasColumnName("Car_code");

                entity.Property(e => e.CustomersCode).HasColumnName("Customers_code");

                entity.Property(e => e.DateOfTerminationOfBooking)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_termination_of_booking");

                entity.Property(e => e.ReservationCost).HasColumnName("Reservation_cost");

                entity.HasOne(d => d.AmenitiesCodeNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.AmenitiesCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Amenities");

                entity.HasOne(d => d.CarCodeNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CarCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Cars");

                entity.HasOne(d => d.CustomersCodeNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomersCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Customers");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarCode)
                    .HasName("PK__Cars__AE8D248922AC4F9B");

                entity.Property(e => e.CarCode).HasColumnName("Car_code");

                entity.Property(e => e.DateOfEntryToTheDatabase)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_entry_to_the_database");

                entity.Property(e => e.DateOfIssueOfTheDatabase)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_issue_of_the_database");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ReleaseYear)
                    .HasColumnType("date")
                    .HasColumnName("Release_year");
            });

            modelBuilder.Entity<CarRentalAgency>(entity =>
            {
                entity.HasKey(e => e.AgencyCode)
                    .HasName("PK__Car_Rent__68189643F34F7EFB");

                entity.ToTable("Car_Rental_Agency");

                entity.Property(e => e.AgencyCode).HasColumnName("Agency_Code");

                entity.Property(e => e.AgencyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Agency_Name");

                entity.Property(e => e.AgencysWebsite)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Agencys_website");

                entity.Property(e => e.AmenitiesCode).HasColumnName("Amenities_code");

                entity.Property(e => e.ContactNumberOfTheAgency)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Contact_number_of_the_Agency");

                entity.Property(e => e.Directions)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("directions");

                entity.Property(e => e.HoursOfWork).HasColumnName("Hours_of_work");

                entity.HasOne(d => d.AmenitiesCodeNavigation)
                    .WithMany(p => p.CarRentalAgencies)
                    .HasForeignKey(d => d.AmenitiesCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Rental_Agency_Amenities");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomersCode)
                    .HasName("PK__Customer__6CC85839E5237E59");

                entity.HasIndex(e => e.ContactNumber, "UQ__Customer__9CA8E8203819CAAB")
                    .IsUnique();

                entity.HasIndex(e => e.PassportData, "UQ__Customer__FEFC69E2AB3B6DBF")
                    .IsUnique();

                entity.Property(e => e.CustomersCode).HasColumnName("Customers_code");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Contact_number");

                entity.Property(e => e.Forename)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LeaderNumberOfTheTrust).HasColumnName("Leader_number_of_the_trust");

                entity.Property(e => e.PassportData)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Passport_data");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentCode)
                    .HasName("PK__Payment__CE839A1A9E7925E5");

                entity.ToTable("Payment");

                entity.Property(e => e.PaymentCode).HasColumnName("Payment_code");

                entity.Property(e => e.BookingCode).HasColumnName("Booking_code");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Payment_amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("Payment_date");

                entity.HasOne(d => d.BookingCodeNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Booking");
            });

            modelBuilder.Entity<PrivateFace>(entity =>
            {
                entity.HasKey(e => e.PrivateFaceCode)
                    .HasName("PK__Private___9FE614B07E8AC9FF");

                entity.ToTable("Private_face");

                entity.HasIndex(e => e.ContactNumber, "UQ__Private___9CA8E820263898FE")
                    .IsUnique();

                entity.Property(e => e.PrivateFaceCode).HasColumnName("Private_face_code");

                entity.Property(e => e.AmenitiesCode).HasColumnName("Amenities_code");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Contact_number");

                entity.Property(e => e.Directions)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("directions");

                entity.Property(e => e.Forename)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AmenitiesCodeNavigation)
                    .WithMany(p => p.PrivateFaces)
                    .HasForeignKey(d => d.AmenitiesCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Private_face_Amenities");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
