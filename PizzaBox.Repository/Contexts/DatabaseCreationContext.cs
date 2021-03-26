using System;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Repository
{
    public class DatabaseCreationContext : DbContext
    {
        public DbSet<AStore> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<APizzaComponent> Comps { get; set; }
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

            modelBuilder.Entity<BasicPizza>(
                eb =>
                {
                    eb.HasKey(ky => new {ky.PresetID, ky.Type});
                    //eb.HasAlternateKey(p => p.PresetID);
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
