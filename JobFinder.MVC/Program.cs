using JobFinder.Application.Repositories.ApplicationUser;
using JobFinder.Application.Repositories.JobApplication;
using JobFinder.Application.Repositories.Vacancy;
using JobFinder.Domain.Entities.Concretes;
using JobFinder.Persistence.Data;
using JobFinder.Persistence.DbContexts;
using JobFinder.Persistence.Repositories.ApplicationUser;
using JobFinder.Persistence.Repositories.JobApplication;
using JobFinder.Persistence.Repositories.Vacancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>
(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("default"));
    }
);


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<IReadApplicationUserRepository, ApplicationUserReadRepository>();
builder.Services.AddScoped<IReadJobApplicationRepository, JobApplicationReadRepository>();
builder.Services.AddScoped<IReadVacanyRepository, VacancyReadRepository>();

builder.Services.AddScoped<IWriteApplicationUserRepository, ApplicationUserWriteRepository>();
builder.Services.AddScoped<IWriteVacanyRepository, VacancyWriteARepository>();
builder.Services.AddScoped<IWriteJobApplicationRepository, JobApplicationWriteRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        await SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during migration or seeding.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();