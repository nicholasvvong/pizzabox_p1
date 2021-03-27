using System;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Junctions;
using PizzaBox.Domain.Models;

namespace PizzaBox.Repository
{
    public class StoreContext : DbContext
    {
        public DbSet<AStore> Stores { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<APizzaComponent> Comps { get; set; }
        public DbSet<BasicPizza> PrePizzas { get; set; }
        public DbSet<PizzaToppingJunction> PTJunc { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // { 
        //     optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Pizzas;Trusted_Connection=True;");
        // }

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
        }
    }
}
