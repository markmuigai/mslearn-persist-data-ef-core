namespace ContosoPizza.Data;

public static class Extensions
{

  /*
  The CreateDbIfNotExists method is defined as an extension of IHost.

  A reference to the PizzaContext service is created.

  EnsureCreated ensures the database exists.

  EnsureCreated creates a new database if one doesn't exist. The new database isn't configured for migrations, so use this with caution.

  The DbIntializer.Initialize method is called, passing the PizzaContext as a parameter.
  */
    public static void CreateDbIfNotExists(this IHost host)
    {
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PizzaContext>();
                context.Database.EnsureCreated();
                DbInitializer.Initialize(context);
            }
        }
    }
}