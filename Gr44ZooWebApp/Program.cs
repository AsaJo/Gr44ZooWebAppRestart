using Gr44ZooWebApp.Data;
using Gr44ZooWebApp.Models.Repos;
using Gr44ZooWebApp.Models.Servises;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ZooDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IAnimalsRepo, InMemoryRepo>();//Ioc
builder.Services.AddScoped<IAnimalsRepo,DatabaseAnimaslRepo>();//Ioc DI
builder.Services.AddScoped<IAnimalsService, AnimalsService>();//Ioc DI







builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();

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
