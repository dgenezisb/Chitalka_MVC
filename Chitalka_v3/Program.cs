using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Chitalka_v3.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Chitalka_v3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Chitalka_v3Context") ?? throw new InvalidOperationException("Connection string 'Chitalka_v3Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
