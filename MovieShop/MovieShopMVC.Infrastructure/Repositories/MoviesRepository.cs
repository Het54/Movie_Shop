using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class MoviesRepository: BaseRepository<Movies>, IMoviesRepository
{
    private readonly MovieShopDbContext _movieShopDbContext;
    public MoviesRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }

    public IEnumerable<Movies> GetHighestGrossingMovies()
    {
        return _movieShopDbContext.Set<Movies>().OrderByDescending(movie => movie.Revenue).Take(12).ToList();
    }

    public IEnumerable<Movies> GetMoviesWithGenres(int genreId)
    {
        return _movieShopDbContext.Set<Movies>().Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre).Where(m => m.MovieGenres.Genre.Id == @genreId);
    }
}