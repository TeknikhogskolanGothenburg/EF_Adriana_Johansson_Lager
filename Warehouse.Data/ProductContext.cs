﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseApp;
using WarehouseApp.Domain;
namespace Warehouse.Data
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderRow> OrderRow { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<CustomerInformation> CustomerInformation { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .EnableSensitiveDataLogging()
            .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Warehouse; Trusted_connection = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>().HasKey(x => new { x.CustomerId, x.ProductId });
        }
    }
}
