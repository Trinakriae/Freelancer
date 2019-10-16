using Freelancer.Business.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Business.Models
{
    public class EFContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<AllocatedTime> AllocatedTimes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["FreelancerDB"];
        //    optionsBuilder.UseSqlServer(settings.ConnectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Surname).HasMaxLength(50);
            });
            modelBuilder.Entity<User>().HasMany(x => x.Customers).WithOne();
            modelBuilder.Entity<User>().HasMany(x => x.Projects).WithOne();

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Description);
                entity.Property(e => e.CustomerId).HasColumnName("IdCustomer");
                entity.Property(e => e.UserId).HasColumnName("IdUser");
            });
            modelBuilder.Entity<Project>().HasMany(x => x.AllocatedTimes).WithOne();

            modelBuilder.Entity<AllocatedTime>(entity =>
            {
                entity.ToTable("AllocatedTime");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description);
                entity.Property(e => e.ProjectId).HasColumnName("IdProject");
                entity.Property(e => e.InvoiceId).HasColumnName("IdInvoice");
            });
           
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CustomerId).HasColumnName("IdCustomer");
            });
            modelBuilder.Entity<Invoice>().HasMany(x => x.InvoiceLines).WithOne();
            modelBuilder.Entity<Invoice>().HasMany(x => x.AllocatedTimes).WithOne();

            modelBuilder.Entity<InvoiceLine>(entity =>
            {
                entity.ToTable("InvoiceLine");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>().HasMany(x => x.Projects).WithOne();
        }
    }
}

