using Data_Access.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Context
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext() : base() { }
        public AppDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<SponsorPhones> SponsorPhones { get; set; }
        public DbSet<Project> Projects { get; set; }    
        public DbSet<TaskProgress> TaskProgress { get; set; }
        public DbSet<ProjectSponsors> ProjectSponsors { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE" },
                new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" }
            );

            modelBuilder.Entity<ApplicationUser>()
                       .HasDiscriminator<string>("Role") // Use "Role" as the discriminator column
                       .HasValue<Employee>("Employee")
                       .HasValue<Manager>("Manager");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("cs"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
