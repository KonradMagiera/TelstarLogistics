using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TelstarLogistics.Models;

namespace TelstarLogistics.Data
{
    public partial class TelstarLogisticsContext : DbContext
    {
        public TelstarLogisticsContext()
        {
        }

        public TelstarLogisticsContext(DbContextOptions<TelstarLogisticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Models.Route> Routes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TelstarLogistics;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Booking");

                entity.Property(e => e.CargoCenterLocations).HasColumnType("text");

                entity.Property(e => e.CustEmail).HasColumnType("text");

                entity.Property(e => e.CustName).HasColumnType("text");

                entity.Property(e => e.Handover).HasColumnType("datetime");

                entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Length).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ParcelType).HasColumnType("text");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Width).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("City");

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<Models.Route>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Route");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TransportType).HasColumnType("text");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User");

                entity.Property(e => e.FirstName).HasColumnType("text");

                entity.Property(e => e.LastName).HasColumnType("text");

                entity.Property(e => e.Password).HasColumnType("text");

                entity.Property(e => e.Role).HasColumnType("text");

                entity.Property(e => e.UserName).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
