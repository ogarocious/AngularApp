using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure appsettings.json for PostgreSQL connection
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services
builder.Services.AddControllers(); // Enables API controllers
builder.Services.AddEndpointsApiExplorer(); // For minimal API support
builder.Services.AddSwaggerGen(); // Adds Swagger for API documentation (optional)

// Add and configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular app URL
              .AllowAnyMethod()                    // Allow all HTTP methods (GET, POST, PUT, DELETE, etc.)
              .AllowAnyHeader();                   // Allow all HTTP headers
    });
});

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enables Swagger in development
    app.UseSwaggerUI();
    Console.WriteLine("Development environment");
    Console.WriteLine("Connection string: " + connectionString);
    Console.WriteLine("Swagger UI is available at /swagger");
}

app.UseRouting(); // Enables routing
app.UseAuthorization(); // Handles authorization (optional if you're not using it)

// Use the CORS policy
app.UseCors("AllowAngularApp");

// Map controllers
app.MapControllers();
app.MapGet("/", () => "Welcome to MyFirstApp in C#!");

// Run the application
app.Run();

/// <summary>
/// Database context for the application
/// </summary>
public class AppDbContext : DbContext
{
    // Constructor to pass options to the base class
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Define DbSets for your models
    public DbSet<Artist> Artists { get; set; }
    public DbSet<StarPurchase> StarPurchases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Add initial artists based on famous rappers
    modelBuilder.Entity<Artist>().HasData(
        new Artist { Id = 1, Name = "Jay-Z", Username = "jayz", TotalStars = 0 },
        new Artist { Id = 2, Name = "Kanye West", Username = "kanyewest", TotalStars = 0 },
        new Artist { Id = 3, Name = "Eminem", Username = "eminem", TotalStars = 0 },
        new Artist { Id = 4, Name = "Tupac Shakur", Username = "tupac", TotalStars = 0 },
        new Artist { Id = 5, Name = "The Notorious B.I.G.", Username = "biggie", TotalStars = 0 },
        new Artist { Id = 6, Name = "Drake", Username = "drake", TotalStars = 0 },
        new Artist { Id = 7, Name = "Kendrick Lamar", Username = "kendricklamar", TotalStars = 0 },
        new Artist { Id = 8, Name = "Lil Wayne", Username = "lilwayne", TotalStars = 0 },
        new Artist { Id = 9, Name = "Nicki Minaj", Username = "nickiminaj", TotalStars = 0 },
        new Artist { Id = 10, Name = "Snoop Dogg", Username = "snoopdogg", TotalStars = 0 }
    );

    base.OnModelCreating(modelBuilder);
}
}