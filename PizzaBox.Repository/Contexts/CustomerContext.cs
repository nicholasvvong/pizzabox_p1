using System;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Repository
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
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
