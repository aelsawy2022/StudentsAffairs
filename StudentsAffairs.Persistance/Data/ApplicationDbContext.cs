using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsAffairs.Persistance.Data.Entities;

namespace StudentsAffairs.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                            new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                            new Role { Id = 2, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" });

            modelBuilder.Entity<Class>().HasData(
                            new Class { Id = 1, Name = "Class 1" },
                            new Class { Id = 2, Name = "Class 2" });
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
    }
}
