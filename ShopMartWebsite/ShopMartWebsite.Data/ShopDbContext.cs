using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopMartWebsite.Entities;

namespace ShopMartWebsite.Data
{
    public class ShopDbContext : IdentityDbContext<User>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Reply> replies { get; set; }

        public DbSet<ImageProduct> images { get; set; }
    }
}
