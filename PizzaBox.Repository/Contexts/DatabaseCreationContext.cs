using System;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Junctions;
using PizzaBox.Domain.Models;

namespace PizzaBox.Repository
{
    public class DatabaseCreationContext : DbContext
    {
        public DbSet<AStore> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PresetPizza> PrePizzas { get; set; }
        public DbSet<APizzaComponent> Comps { get; set; }
        public DbSet<PizzaToppingJunction> PTJunc { get; set; }
        public DbSet<PizzaOrderJunction> POJunc { get; set; }
        public DbSet<OrderCustomerJunction> OCJunc { get; set; }
        public DatabaseCreationContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Pizzas;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemType>(
                o=>
                {
                    o.HasIndex(t => t.Name).IsUnique();
                });

            modelBuilder.Entity<APizzaComponent>(
                o=>
                {
                    o.HasIndex(x => x.Name).IsUnique();
                });
            modelBuilder.Entity<PizzaToppingJunction>(
                o=>
                {
                    o.HasKey(ky => new{ky.PresetPizzaID, ky.ToppingID});
                });
            modelBuilder.Entity<PizzaOrderJunction>(
                o=>
                {
                    o.HasKey(ky => new{ky.PresetPizzaID, ky.OrderID});
                });
            modelBuilder.Entity<OrderCustomerJunction>(
                o=>
                {
                    o.HasKey(ky => new{ky.OrderID, ky.CustomerID});
                });
            modelBuilder.Entity<PresetPizza>(
                o=>
                {
                    o.HasKey(ky => new{ky.StoreID, ky.PresetID});
                });

            modelBuilder.Entity<BasicPizza>(
                eb =>
                {
                    eb.HasKey(ky => new {ky.PresetID}); //ky.Type});
                });

            modelBuilder.Entity<AStore>(
                store =>
                {
                    store.HasMany(p => p.PresetPizzas);
                });
            modelBuilder.Entity<Order>(
                o =>
                {
                    o.HasMany(p => p.Pizzas);
                });
            
        }
    }
}
