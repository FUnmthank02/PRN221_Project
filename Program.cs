using Microsoft.AspNetCore.Mvc;
using PRN221_Project.Business.IRepository;
using PRN221_Project.Business.Mapping;
using PRN221_Project.Business.Middleware;
using PRN221_Project.Business.Repository;
using PRN221_Project.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register DI
builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>()
    .AddDbContext<PRN221_AssContext>(opt =>
    builder.Configuration.GetConnectionString("PRN221_Ass"));

builder.Services.AddTransient<IAttendanceRepository, AttendanceRepository>()
    .AddDbContext<PRN221_AssContext>(opt =>
    builder.Configuration.GetConnectionString("PRN221_Ass"));

// Register auto mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configure session state
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

// using session
app.UseSession();

// using middleware
app.UseMiddleware<AuthorizeMiddleware>();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
