using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProjectMvc.Data;
using ProjectMvc.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjectMvcContext>(options =>
  options.UseMySql(
        builder.Configuration.GetConnectionString("ProjectMvcContext"), // Nome da string no appsettings.json
        new MySqlServerVersion(new Version(8, 0, 36)), // Coloque a versão real do seu MySQL
        mySqlOptions => mySqlOptions.MigrationsAssembly("ProjectMvc")));
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SalllerService>();
builder.Services.AddScoped<DepartamentService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seeder.Seed();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
