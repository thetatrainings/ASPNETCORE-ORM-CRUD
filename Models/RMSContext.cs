using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORMCrudOperations.Models
{
    public partial class RMSContext : DbContext
    {
        public RMSContext()
        {
        }

        public RMSContext(DbContextOptions<RMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airline { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LENOVO\\SQLEXPRESS;Database=RMS;Trusted_Connection=True;User ID=sa; Password=theta;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Airline>(entity =>
            {
                entity.ToTable("airline");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ShortCode)
                    .HasColumnName("short_code")
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AirlineId).HasColumnName("airline_id");

                entity.Property(e => e.ArrivalDateTime)
                    .HasColumnName("arrival_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartialDateTime)
                    .HasColumnName("departial_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasMaxLength(50);

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasMaxLength(50);
            });
        }
    }
}
