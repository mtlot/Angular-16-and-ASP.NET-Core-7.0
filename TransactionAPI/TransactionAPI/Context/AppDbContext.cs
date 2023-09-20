using Microsoft.EntityFrameworkCore;
using TransactionAPI.Models;

namespace TransactionAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // User Configuration
            builder.Entity<User>().ToTable("users");

            // Group Configuration
            builder.Entity<Group>().HasKey(g => g.Id);
            builder.Entity<Group>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Group>()
                .HasOne(g => g.User)
                .WithMany(u => u.Groups) // Assuming User has a collection of Groups
                .HasForeignKey(g => g.UserId);

            // Event Configuration
            builder.Entity<Event>().HasKey(e => e.Id);
            builder.Entity<Event>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
