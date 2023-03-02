using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.Data;

/*
The constructor accepts a parameter of type DbContextOptions<PizzaContext>. 
This allows external code to pass in the configuration, so the same DbContext
can be shared between test and production code and even used with different providers.
The DbSet<T> properties correspond to tables to be created in the database.
The table names will match the DbSet<T> property names in the PizzaContext class. This behavior can be overridden if needed.
When instantiated, PizzaContext will expose Pizzas, Toppings, and Sauces properties.
Changes you make to the collections exposed by those properties will be propagated to the database.
*/
public class PizzaContext : DbContext
{
    public PizzaContext (DbContextOptions<PizzaContext> options)
        : base(options)
    {
    }

    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Topping> Toppings => Set<Topping>();
    public DbSet<Sauce> Sauces => Set<Sauce>();
}