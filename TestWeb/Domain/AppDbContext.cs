using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TestWeb.Domain.Entities;

namespace TestWeb.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole[]
                {
                    new()
                    {
                        Id = "5fde4c7b-8e51-4d0a-a106-2b7f5185f88c",
                        Name = "admin",
                        NormalizedName = "ADMIN"
                    },
                    new()
                    {
                        Id = "f503160a-4e9d-4084-b59b-0970133ee4b9",
                        Name = "moderator",
                        NormalizedName = "MODERATOR"
                    },
                    new()
                    {
                        Id = "d0478454-9965-40ad-85ad-737ff8bce7a1",
                        Name = "user",
                        NormalizedName = "USER"
                    }
                });

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser[]
                {
                    new()
                    {
                        Id = "d63b302d-1b32-4cb8-b44a-0cc947e5dcb2",
                        UserName = "Admin",
                        NormalizedUserName = "ADMIN",
                        Email = "admin@email.com",
                        NormalizedEmail = "ADMIN@EMAIL.COM",
                        EmailConfirmed = true,
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
                        SecurityStamp = String.Empty
                    },
                    new()
                    {
                        Id = "fa6619f2-953a-42f1-a38c-834e0c6dbf3e",
                        UserName = "Moderator",
                        NormalizedUserName = "MODERATOR",
                        Email = "moderator@email.com",
                        NormalizedEmail = "MODERATOR@EMAIL.COM",
                        EmailConfirmed = true,
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "moderator"),
                        SecurityStamp = String.Empty
                    },
                    new()
                    {
                        Id = "2ea58f94-9c39-485d-bcec-b3f68719da9c",
                        UserName = "user",
                        NormalizedUserName = "USER",
                        Email = "user@email.com",
                        NormalizedEmail = "USER@EMAIL.COM",
                        EmailConfirmed = true,
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "user"),
                        SecurityStamp = String.Empty
                    }
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>[]
                {
                    new()
                    {
                        UserId = "d63b302d-1b32-4cb8-b44a-0cc947e5dcb2",
                        RoleId = "5fde4c7b-8e51-4d0a-a106-2b7f5185f88c",
                    },
                    new()
                    {
                        UserId = "fa6619f2-953a-42f1-a38c-834e0c6dbf3e",
                        RoleId = "f503160a-4e9d-4084-b59b-0970133ee4b9"
                    },
                    new()
                    {
                        UserId = "2ea58f94-9c39-485d-bcec-b3f68719da9c",
                        RoleId = "d0478454-9965-40ad-85ad-737ff8bce7a1"
                    }
                });

            builder.Entity<News>().HasData(
                new News[]
                {
                    new()
                    {
                        Id = new Guid("0904e177-fadd-43ea-94b3-1990cb0f333b"),
                        CodeWord = "new News",
                        Title = "Great News!",
                        Text = "TestTextTestTextTestTextTestTextTestTextTestTextTestTextTestTextTestTextTestTextTestTextTestTextTestTextTestTextTestTextTestText"
                    }
                });
        }
    }
}
