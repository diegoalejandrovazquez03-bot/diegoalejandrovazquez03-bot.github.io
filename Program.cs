using PescaderiaApi.Interfaces;
using PescaderiaApi.Repositories;
using Microsoft.EntityFrameworkCore;
using PescaderiaApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure EF Core depending on environment and connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment() || 
        (connectionString != null && (connectionString.Contains("Server=") || connectionString.Contains("Database=")) && !connectionString.Contains("Server=BU")))
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        // Fallback for production (Render) or when SQL Server is not available
        options.UseSqlite("Data Source=pescaderia.db");
    }
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowGitHubPages",
        policy => policy.WithOrigins("https://diegoalejandrovazquez03-bot.github.io")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register Dependency Injection (OOP best practices) - now Scoped since DbContext is Scoped
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowGitHubPages");

app.UseHttpsRedirection();

// Serve static files from wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

// Handle client-side routing fallback to React index.html
app.MapFallbackToFile("index.html");

// Ensure DB is created and seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al inicializar y sembrar la base de datos.");
    }
}

app.Run();


