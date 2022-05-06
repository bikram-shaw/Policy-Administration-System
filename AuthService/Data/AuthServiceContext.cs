using Microsoft.EntityFrameworkCore;

namespace AuthService.Data
{
    public class AuthServiceContext : DbContext
    {
        public AuthServiceContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasData(
                  new User() { Id=100,Username = "Admin", Password = "Admin" },
                  new User() { Id = 101, Username = "User", Password = "User" },
                  new User() { Id = 102, Username = "Manisha", Password = "12345" }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}
