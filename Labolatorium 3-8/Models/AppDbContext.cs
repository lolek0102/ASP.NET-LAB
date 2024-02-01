using Labolatorium_3_8.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Labolatorium_3_8.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ShippingCarrier> ShippingCarriers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Product.db");
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja relacji między Product, Supplier i ShippingCarrier
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict); // Dodano OnDelete

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ShippingCarrier)
                .WithMany(sc => sc.Products)
                .HasForeignKey(p => p.ShippingCarrierId)
                .OnDelete(DeleteBehavior.Restrict); // Dodano OnDelete

            // Seedowanie danych
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Supplier 1" },
                new Supplier { Id = 2, Name = "Supplier 2" }
            );

            modelBuilder.Entity<ShippingCarrier>().HasData(
                new ShippingCarrier { Id = 1, Name = "Carrier 1" },
                new ShippingCarrier { Id = 2, Name = "Carrier 2" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Price = 100,
                    Manufacturer = "Manufacturer 1",
                    ProductionDate = DateTime.Now,
                    Description = "Description 1",
                    SupplierId = 1,
                    ShippingCarrierId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Price = 200,
                    Manufacturer = "Manufacturer 2",
                    ProductionDate = DateTime.Now,
                    Description = "Description 2",
                    SupplierId = 2,
                    ShippingCarrierId = 2
                }
            );
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            // dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            // utworzenie administratora jako użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADAM@WSEI.EDU.PL"
            };

            // haszowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");

            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);

            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            });
            string USER_ID = Guid.NewGuid().ToString();

            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "user@esei.edu.pl",
                EmailConfirmed = true,
                UserName = "user",
                NormalizedUserName = "USER",
                NormalizedEmail = "USER@WSEI.EDU.PL"

            };

            user.PasswordHash = ph.HashPassword(user, "user");
            modelBuilder.Entity<IdentityUser>().HasData(user);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            });


        }
    }
}