using Microsoft.EntityFrameworkCore;
using WebApplicationDTS.Models;

namespace WebApplicationDTS.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        // Mendaftarkan Model ke Dalam Context/ Database
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }


        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relasi antara satu University dengan banyak Education
            modelBuilder.Entity<University>()
                        .HasMany(u => u.Educations)
                        .WithOne(e => e.Universities)
                        .HasForeignKey(u => u.UniversityId)
                        .OnDelete(DeleteBehavior.NoAction);

            /*modelBuilder.Entity<Education>()
                        .HasOne(e => e.University)
                        .WithMany(u => u.Educations)
                        .HasForeignKey(e => e.UniversityId);*/
        }
    }
}
