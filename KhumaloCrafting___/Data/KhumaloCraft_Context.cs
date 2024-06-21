﻿using KhumaloCrafting___.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KhumaloCrafting___.Data
{
    public class KhumaloCraft_Context : IdentityDbContext<ApplicationUser>
    {
        public KhumaloCraft_Context(DbContextOptions<KhumaloCraft_Context> options)
           : base(options)
        {
        }


        public DbSet<Products> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CraftworkProduct>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Products>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(p => p.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(p => p.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ShoppingCart>()
                .Property(p => p.TotalPrice)
                .HasColumnType("decimal(18,2)");

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}

