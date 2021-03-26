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
            modelBuilder.Entity<APizzaComponent>(
                o=>
                {
                    o.HasIndex(x => x.Name).IsUnique();
                    o.HasData(
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "beef", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "chicken", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "ham", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "mushroom", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "olive", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "peppers", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "pepporoni", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "pineapple", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "salami", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "sausage", Type = "topping"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "small", Type = "size"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "medium", Type = "size"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "large", Type = "size"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "extra large", Type = "size"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "regular", Type = "crust"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "hand-tossed", Type = "crust"},
                        new APizzaComponent(){CompID = Guid.NewGuid(),Name = "thin", Type = "crust"}
                    );
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
                    // store.HasData(new CaliforniaStore 
                    // {
                    //     StoreID = Guid.NewGuid()

                    // });
                });
            modelBuilder.Entity<Order>(
                o =>
                {
                    o.HasMany(p => p.Pizzas);
                });
            
        }
    }
}
