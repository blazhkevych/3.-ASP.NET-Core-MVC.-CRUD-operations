using CRUD_operations.Models;
using Microsoft.EntityFrameworkCore;

// Create a new WebApplication builder with the provided command-line arguments
var builder = WebApplication.CreateBuilder(args);
// Retrieve the connection string from the configuration
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add the DbContext to the service collection, configuring it to use SQL Server with the connection string
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(connection));
// Add services to the container
// In this case, we're adding the controllers and views services to the container
builder.Services.AddControllersWithViews();
// Build the application using the configured services and settings
var app = builder.Build();
// Configure the HTTP request pipeline
// If the application is not in development mode, use the exception handler middleware and HSTS
if (!app.Environment.IsDevelopment())
{
    // Use the exception handler middleware to handle exceptions and provide a user-friendly error page
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Use HTTPS redirection middleware to redirect HTTP requests to HTTPS
app.UseHttpsRedirection();
// Use static files middleware to serve static files
app.UseStaticFiles();
// Use routing middleware to route requests to the correct endpoint
app.UseRouting();
// Use authorization middleware to authorize users
app.UseAuthorization();
// Map the default controller route
app.MapControllerRoute(
    "default",
    "{controller=Movies}/{action=Index}/{id?}");
// Run the application
app.Run();