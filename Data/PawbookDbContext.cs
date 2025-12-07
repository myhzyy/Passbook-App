using Microsoft.EntityFrameworkCore;
using Pawbook.Models;

namespace Pawbook.Data;

public class PawbookDbContext : DbContext
{
    public PawbookDbContext(DbContextOptions<PawbookDbContext> options)
        : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User {
                Id = 1,
                Username = "BabyJasper",
                Age = 1,
                Breed = "Cockapoo",
                Gender = "Male"
            },
            new User {
                Id = 2,
                Username = "LunaTheLab",
                Age = 3,
                Breed = "Labrador",
                Gender = "Female"
            },
            new User {
                Id = 3,
                Username = "SamsonTheDood",
                Age = 2,
                Breed = "Goldendoodle",
                Gender = "Male"
            }
        );

        
        modelBuilder.Entity<Post>().HasData(
            new Post {
                Id = 1,
                UserId = 1,
                ImageUrl = "/Images/BabyJasper1/BabyJasper-1.jpg",
                Caption = "Enjoying a walk today!",
                Likes = 10,
                CreatedAt = new DateTime(2025, 01, 01)
            },
            new Post {
                Id = 2,
                UserId = 2,
                ImageUrl = "/Images/Luna-the-lab/Luna-the-lab.jpg",
                Caption = "Found my favourite stick 🪵",
                Likes = 22,
                CreatedAt = new DateTime(2025, 01, 01)
            },
            new Post {
                Id = 3,
                UserId = 3,
                ImageUrl = "/Images/Samson-thedood/Samson-thedood-1.jpg",
                Caption = "Snuggles time.",
                Likes = 14,
                CreatedAt = new DateTime(2025, 01, 01)
            }
        );
        
    }
}