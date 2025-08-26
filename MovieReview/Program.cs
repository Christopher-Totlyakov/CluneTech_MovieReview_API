using Contracts.Repository;
using MovieReview.Configuration;
using Microsoft.EntityFrameworkCore;
using Repository;
using Infrastructure.Middlewares;


// Creates a new `WebApplicationBuilder` instance**, which:
// - Sets up the default host (web server, logging, configuration, etc.)
// - Loads configuration from `appsettings.json`, environment variables, command-line arguments, etc.
// - Sets up dependency injection (DI)
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(connectionString));
// Registers MVC controllers to the DI container. This enables routing, model binding, and controller-based API endpoints.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// This service makes your endpoints visible to Swagger/OpenAPI for documentation purposes, including those defined with:
builder.Services.AddEndpointsApiExplorer();

// Registers Swagger generation into the DI container so you can produce OpenAPI documentation (used by tools like Swagger UI or Postman)
builder.Services.AddSwaggerGen();

// To register a service to the dependency injection (DI) we use the builder.Services collection.

// Lifetime Options:
// AddSingleton<T>()	One instance for the entire app lifetime.
// AddScoped<T>()	One instance per HTTP request.
// AddTransient<T>()	New instance every time it's requested.

// builder.Services.AddScoped<IMyService, MyService>();

builder.Services.ConfigureServices(builder.Configuration);

// Builds the `WebApplication` object using the services and configuration set up earlier. From here, middleware and HTTP pipeline logic are configured.
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
// Conditionally enables Swagger UI and middleware only in development environment.
if (app.Environment.IsDevelopment())
{
    // Generates the Swagger JSON file.
    app.UseSwagger();
    // Shows the Swagger UI frontend to interact with the API.
    app.UseSwaggerUI();
}

// Middleware that **redirects HTTP requests to HTTPS**, improving security by enforcing secure communication.
app.UseHttpsRedirection();

app.UseAuthentication();
// Adds the authorization middleware to the pipeline.
// This doesn't authenticate users but checks if authenticated users are authorized to access specific endpoints (e.g., based on [Authorize] attributes).
app.UseAuthorization();

// Maps the controller endpoints to the request pipeline.
// -This tells the application to use **attribute routing** (e.g., `[Route("api/[controller]")]`) to match requests to controller actions.
app.MapControllers();

// Starts the application and begins listening for HTTP requests.
app.Run();