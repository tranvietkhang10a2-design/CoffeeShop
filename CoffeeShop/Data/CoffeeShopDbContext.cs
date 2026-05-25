using System;
using System.Collections.Generic;
using CoffeeShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Models;

namespace CoffeeShop.Data;

public class CoffeeShopDbContext : DbContext
{
    public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
    //seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
        new Product { Id = 1, Name = "America", Price = 25, Detail = "Name product", ImgUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" }, new Product { Id = 2, Name = "Vietnam", Price = 20, Detail = "Vietnamese product", ImgUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee1024x536.webp" },
       new Product { Id = 3, Name = "United Kingdom", Price = 15, Detail = "UK product", ImgUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" },
        new Product { Id = 4, Name = "India", Price = 15, Detail = "India product", ImgUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" }, new Product { Id = 5, Name = "Russian", Price = 25, Detail = "Russian product", ImgUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee1024x536.webp" },
        new Product { Id = 6, Name = "France", Price = 35, Detail = "France product", ImgUrl = "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp" }
        );
    }
}
