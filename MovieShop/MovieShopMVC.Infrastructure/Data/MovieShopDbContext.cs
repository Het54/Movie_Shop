using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Infrastructure.Data;

public class MovieShopDbContext: DbContext
{

    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Movies> Movies { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Genres> Genres { get; set; }
    public DbSet<Casts> Casts { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<MovieGenres> MovieGenres { get; set; }
    public DbSet<MovieCasts> MovieCasts { get; set; }
    public DbSet<Trailers> Trailers { get; set; }
    public DbSet<Favorites> Favorites { get; set; } 
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<Purchases> Purchases { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorites>().HasKey(e => new { e.MovieId, e.UserId });
        modelBuilder.Entity<MovieCasts>().HasKey(e => new { e.CastId, e.MovieId });
        modelBuilder.Entity<MovieGenres>().HasKey(e => new { e.GenreId, e.MovieId });
        modelBuilder.Entity<Purchases>().HasKey(e => new { e.MovieId, e.UserId });
        modelBuilder.Entity<Reviews>().HasKey(e => new { e.MovieId, e.UserId });
        modelBuilder.Entity<UserRoles>().HasKey(e => new { e.RoleId, e.UserId });
    }
    
}