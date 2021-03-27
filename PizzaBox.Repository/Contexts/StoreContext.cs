using System;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
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
        public DbSet<BasicPizza> BasicPizza { get; set; }
        public DbSet<PresetPizza> PresetPizza { get; set; }

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
            // modelBuilder.Entity<Topping>()
            //         .HasMany(u => u.Pizzas)
            //         .WithMany(g => g.Toppings)
            //         .UsingEntity<PresetPizza>(
            //             j => j.HasOne(w => w.BasicPizza).WithMany(g => g.PresetPizzas),
            //             j => j.HasOne(w => w.Topping).WithMany(u => u.PresetPizzas));
            modelBuilder.Entity<BasicPizza>(
                eb =>
                {
                    eb.HasKey(ky => new {ky.PresetID});
                    eb.HasMany(u => u.Toppings)
                    .WithMany(g => g.Pizzas).UsingEntity<PresetPizza>(
                        j => j.HasOne(w => w.Topping).WithMany(g => g.PresetPizzas),
                        j => j.HasOne(w => w.BasicPizza).WithMany(u => u.PresetPizzas));
                    //eb.HasAlternateKey(p => p.PresetID);
                });
            modelBuilder.Entity<PresetPizza>(
                eb =>
                {
                    eb.HasKey(ky => new {ky.BasicPizzaID, ky.ToppingID});
                    eb.HasOne(p => p.BasicPizza).WithMany(o => o.PresetPizzas).HasForeignKey(k => k.BasicPizzaID);
                    eb.HasOne(p => p.Topping).WithMany(o => o.PresetPizzas).HasForeignKey(k => k.ToppingID);
                    //eb.HasAlternateKey(p => p.PresetID);
                });

            modelBuilder.Entity<AStore>(
                store =>
                {
                    store.HasMany(p => p.PresetPizzas);
                    //store.HasData(new CaliforniaStore());
                });
        }
    }
}
