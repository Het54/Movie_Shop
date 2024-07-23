using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Infrastructure.Data;
using MovieShopMVC.Infrastructure.Repositories;
using MovieShopMVC.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieShopDb"));
});

builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IGenresService, GenresService>();
builder.Services.AddScoped<IGenresRepository, GenresRepository>();
builder.Services.AddScoped<ITrailersRepository, TrailersRepository>();
builder.Services.AddScoped<ITrailersService, TrailersService>();
builder.Services.AddScoped<IMovieCastsRepository, MovieCastsRepository>();
builder.Services.AddScoped<IMovieCastsService, MovieCastsService>();
builder.Services.AddScoped<ICastsRepository, CastsRepository>();
builder.Services.AddScoped<ICastsService, CastsService>();


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