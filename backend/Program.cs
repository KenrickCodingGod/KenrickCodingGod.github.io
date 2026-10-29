
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server verbinding
var connectionString = builder.Configuration
    .GetConnectionString("PortfolioDatabase");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "De database connectionstring ontbreekt."
    );
}


builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseSqlServer(
        connectionString,
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
    )
);


// Services registreren
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<BlogpostService>();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Controllers activeren
app.MapControllers();

// Database tabellen aanmaken met EF Core
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<PortfolioDbContext>();

    await db.Database.EnsureCreatedAsync();
}

// Applicatie starten
app.Run();
