using System;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Repository
{
    public class StoreContext : DbContext
    {
        public DbSet<AStore> Stores { get; set; }
        public DbSet<PresetPizza> PresetPizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // { 
        //     optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Pizzas;Trusted_Connection=True;");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicPizza>(
                eb =>
                {
                    eb.HasNoKey();
                });

            modelBuilder.Entity<AStore>(
                store =>
                {
                    store.HasMany(p => p.PresetPizzas);
                });
        }
    }
}
