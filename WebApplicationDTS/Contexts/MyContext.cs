﻿using Microsoft.EntityFrameworkCore;
using WebApplicationDTS.Models;
using WebApplicationDTS.ViewModels;

namespace WebApplicationDTS.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        // Mendaftarkan Model ke Dalam Context/ Database
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Role> Roles { get; set; }


        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relasi antara satu University dengan banyak Education
            modelBuilder.Entity<University>()
                        .HasMany(u => u.Educations)
                        .WithOne(e => e.University)
                        .HasForeignKey(u => u.UniversityId)
                        .OnDelete(DeleteBehavior.NoAction);

            // Relasi antara satu Education dengan satu Profiling
            modelBuilder.Entity<Profiling>()
                     .HasOne(p => p.Education)
                     .WithOne(e => e.Profiling)
                     .HasForeignKey<Profiling>(p => p.EducationId)
                     .OnDelete(DeleteBehavior.NoAction);

            // Relasi antara satu Profiling dengan satu Employee
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Profiling)
                        .WithOne(p => p.Employee)
                        .HasForeignKey<Profiling>(p => p.EmployeeNik)
                        .OnDelete(DeleteBehavior.NoAction);

            // Relasi antara satu Role dengan banyak Account Roles
            modelBuilder.Entity<Role>()
                        .HasMany(ar => ar.AccountRoles)
                        .WithOne(r => r.Role)
                        .HasForeignKey(ar => ar.RoleId)
                        .OnDelete(DeleteBehavior.NoAction);

            // Relasi antara satu Account dengan banyak Account Roles
            modelBuilder.Entity<Account>()
                        .HasMany(ar => ar.AccountRoles)
                        .WithOne(a => a.Account)
                        .HasForeignKey(ar => ar.AccountNik)
                        .OnDelete(DeleteBehavior.NoAction);

            // Relasi antara satu Account dengan satu Employee
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Account)
                        .WithOne(a => a.Employee)
                        .HasForeignKey<Account>(a => a.EmployeeNik)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RegisterVM>()
                        .HasNoKey();

            modelBuilder.Entity<LoginVM>()
                        .HasNoKey();

            /*modelBuilder.Entity<Education>()
                        .HasOne(e => e.University)
                        .WithMany(u => u.Educations)
                        .HasForeignKey(e => e.UniversityId);*/
        }  
    }
}
