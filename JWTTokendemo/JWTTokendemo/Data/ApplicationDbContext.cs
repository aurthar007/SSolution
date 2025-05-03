using JWTTokendemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTTokendemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<State>States  { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        public DbSet<TaskManager> TaskManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Teacher" },
                new Role { Id = 3, Name = "Student" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "anil@gmail.com", Firstname = "Anil", Lastname = "Sah", Password = "Anil@123", Mobile = "9808000008" },
                new User { Id = 2, Email = "raju@gmail.com", Firstname = "Raju", Lastname = "Chauhan", Password = "Raju@123", Mobile = "9808009797" },
                new User { Id = 3, Email = "avijit@gmail.com", Firstname = "Avijit", Lastname = "Gorai", Password = "Avijit@123", Mobile = "998989797" }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, UserId = 1, RoleId = 1 },
                new UserRole { Id = 2, UserId = 2, RoleId = 2 },
                new UserRole { Id = 3, UserId = 3, RoleId = 3 });

            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, StatusName = "To Do" },
                new Status { Id = 2, StatusName = "In Progress" },
                new Status { Id = 3, StatusName = "Testing" },
                new Status { Id = 4, StatusName = "Done" }
            );
        }
    }
}
