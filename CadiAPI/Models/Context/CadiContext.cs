using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models.Context
{
    public class CadiContext : DbContext
    {
        public CadiContext(DbContextOptions<CadiContext> options)
            : base(options)
        {

        }
        //Produtos
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Additional> Additionals { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<OptionsProduct> OptionsProducts { get; set; }
        public DbSet<AdditionalProduct> AdditionalProducts { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<CashierOrder> CashierOrders { get; set; }
        public DbSet<Table> Tables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ProductId });
            });
            modelBuilder.Entity<OptionsProduct>(entity =>
            {
                entity.HasKey(e => new { e.OptionsId, e.ProductId });
            });
            modelBuilder.Entity<AdditionalProduct>(entity =>
            {
                entity.HasKey(e => new { e.AdditionalId, e.ProductId });
            });
        }

    }
}
