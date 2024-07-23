using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class MovieCastsRepository: BaseRepository<MovieCasts>, IMovieCastsRepository
{
    private readonly MovieShopDbContext _movieShopDbContext;

    public MovieCastsRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }

    public List<MovieCasts> GetCastsByMovieId(int movieId)
    {
        return _movieShopDbContext.Set<MovieCasts>().Where(movieCast => movieCast.MovieId == movieId)
            .Include(movieCast => movieCast.Cast).ToList();
    }

    public List<MovieCasts> GetMoviesByCastId(int castId)
    {
        return _movieShopDbContext.Set<MovieCasts>().Where(movieCast => movieCast.CastId == castId)
            .Include(movieCast => movieCast.Movie).ToList();
    }
}