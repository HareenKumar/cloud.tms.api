using cloud.tms.application.Services;
using cloud.tms.domain.Repository;
using cloud.tms.infrastructure.Persistence.PostgreSQL;
using cloud.tms.infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Infrastructure Services
//builder.Services.AddInfrastructureServices(builder.Configuration);

// Register application services (if needed)
//builder.Services.AddScoped<LocationService>();
//builder.Services.Scan(scan => scan.FromAssemblies(Assembly.Load("cloud.tms.application")) .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service"))) .AsImplementedInterfaces().WithSingletonLifetime());
//builder.Services.Scan(scan => scan.FromAssemblies(Assembly.Load("cloud.tms.infrastructure")).AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository"))).AsImplementedInterfaces().WithSingletonLifetime());

//builder.Services.Scan(scan => scan
//    .FromApplicationDependencies() // Scan all application dependencies
//        .AddClasses(classes => classes.InNamespaces("cloud.tms.domain.Interfaces")) // Repositories namespace
//            .AsImplementedInterfaces()
//            .WithScopedLifetime()
//        .AddClasses(classes => classes.InNamespaces("cloud.tms.application.Repository")) // Services namespace
//            .AsSelf()
//            .WithScopedLifetime());


//builder.Services.Scan(scan => scan
//    .FromAssemblyOf<IMasterRepository>() // Specify the assembly containing IShipmentRepository
//        .AddClasses(classes => classes.AssignableTo<IMasterRepository>()) // Find all classes implementing IShipmentRepository
//            .AsImplementedInterfaces() // Register them by their implemented interfaces
//            .WithScopedLifetime() // Set Scoped lifetime
//    .FromAssemblyOf<LocationService>() // Specify the assembly containing ShipmentService
//        .AddClasses(classes => classes.AssignableTo<LocationService>()) // Find the ShipmentService class
//            .AsSelf() // Register ShipmentService as itself
//            .WithScopedLifetime()); // Set Scoped lifetime


// Dependency Injection
builder.Services.AddScoped<IMasterRepository, MastersRepository>();
builder.Services.AddScoped<LocationService>();

builder.Services.AddDbContext<AppPostgreSQLDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("localpgsql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast =  Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast")
//.WithOpenApi();

app.Run();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
