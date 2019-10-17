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
            modelBuilder.Entity<User>().HasMany(u => u.Customers).WithOne(c => c.User);
            modelBuilder.Entity<User>().HasMany(u => u.Projects).WithOne(p => p.User);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Description);
                //entity.Property(e => e.CustomerId).HasColumnName("IdCustomer");
                //entity.Property(e => e.UserId).HasColumnName("IdUser");
            });
            modelBuilder.Entity<Project>().HasMany(p => p.AllocatedTimes).WithOne(at => at.Project);

            modelBuilder.Entity<AllocatedTime>(entity =>
            {
                entity.ToTable("AllocatedTime");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description);
                //entity.Property(e => e.ProjectId).HasColumnName("IdProject");
                //entity.Property(e => e.InvoiceId).HasColumnName("IdInvoice");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");
                entity.HasKey(e => e.Id);
                //entity.Property(e => e.CustomerId).HasColumnName("IdCustomer");
            });
            //Aggregation relationship
            modelBuilder.Entity<Invoice>().HasMany(i => i.InvoiceLines).WithOne(il => il.Invoice).IsRequired();
            modelBuilder.Entity<Invoice>().HasMany(i => i.AllocatedTimes).WithOne(at => at.Invoice);

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
            modelBuilder.Entity<Customer>().HasMany(c => c.Projects).WithOne(p => p.Customer);
            modelBuilder.Entity<Customer>().HasMany(c => c.Invoices).WithOne(p => p.Customer);
        }
    }
}

