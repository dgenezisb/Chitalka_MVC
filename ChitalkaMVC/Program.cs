using Microsoft.EntityFrameworkCore;
using ChitalkaMVC.Storage;
using ChitalkaMVC.Logic.Countries;
using ChitalkaMVC.Logic.Centuries;
using ChitalkaMVC.Logic.Books;
using ChitalkaMVC.Logic.Genres;
using ChitalkaMVC.Logic.Users;
using ChitalkaMVC.Logic.Authors;
using ChitalkaMVC.Logic.Notes;
using ChitalkaMVC.Logic.UserBooks;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();//.AddRazorRuntimeCompilation();
services.AddScoped<ICountryManager, CountryManager>();
services.AddScoped<ICenturyManager, CenturyManager>();
services.AddScoped<IUserManager, UserManager>();
services.AddScoped<IGenreManager, GenreManager>();
services.AddScoped<IAuthorManager, AuthorManager>();
services.AddScoped<INoteManager, NoteManager>();
services.AddScoped<IBookManager, BookManager>();
services.AddScoped<IUserBookManager, UserBookManager>();

services.AddDistributedMemoryCache();

services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var connectionString = builder.Configuration.GetConnectionString("DbCon");
services.AddDbContext<ChitalkaContext>(param => param.UseSqlServer(connectionString));

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
