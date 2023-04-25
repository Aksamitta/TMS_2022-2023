using Lab35_Aksana.Patrubeika_Practice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System;
using System.Collections.Generic;

namespace Lab35_Aksana.Patrubeika_Practice.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<Auto> Autos { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Magazine> Magazines { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>().HasData(
                new Client() { ClientId = 1, ClientName = "Nick", ClientSname = "First" },
                new Client() { ClientId = 2, ClientName = "Chack", ClientSname = "Second" },
                new Client() { ClientId = 3, ClientName = "Andry", ClientSname = "Third" }
                );

            builder.Entity<Role>().HasData(
               new Role() {RoleId = 1, RoleName = "Seller", RoleSalary = 2000 }               
               );

            builder.Entity<Employee>().HasData(
               new Employee() { EmployeeId = 1, EmployeeName = "Mike Lang", RoleId = 1 },
               new Employee() { EmployeeId = 2, EmployeeName = "Jhon Jhon", RoleId = 1 },
               new Employee() { EmployeeId = 3, EmployeeName = "Nick Nick", RoleId = 1 }
               );

            builder.Entity<Magazine>().HasData(
               new Magazine() { MagazineId = 1, ClientId = 1, AutoId = 1, EmployeeId = 1 },
               new Magazine() { MagazineId = 2, ClientId = 2, AutoId = 4, EmployeeId = 2 },
               new Magazine() { MagazineId = 3, ClientId = 3, AutoId = 5, EmployeeId = 3 }
               );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=USER-PC;Initial Catalog=Lab35_Practice;Integrated Security=True;TrustServerCertificate=True");

        
    }
}

