using ContosoPizza.Services;
// Additional using declarations
using ContosoPizza.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
The constructor accepts a parameter of type DbContextOptions<PizzaContext>. 
This allows external code to pass in the configuration, so the same DbContext
 can be shared between test and production code and even used with different providers.
The DbSet<T> properties correspond to tables to be created in the database.
The table names will match the DbSet<T> property names in the PizzaContext class.
 This behavior can be overridden if needed.
When instantiated, PizzaContext will expose Pizzas, Toppings, and Sauces properties. 
Changes you make to the collections exposed by those properties will be propagated to the database.
*/
// Add the PizzaContext
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");
// Add the PromotionsContext

builder.Services.AddScoped<PizzaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Add the CreateDbIfNotExists method call

app.Run();
