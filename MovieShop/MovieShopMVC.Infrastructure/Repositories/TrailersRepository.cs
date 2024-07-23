using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class TrailersRepository: BaseRepository<Trailers>, ITrailersRepository
{
    private readonly MovieShopDbContext _movieShopDbContext;

    public TrailersRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }
    
    public List<Trailers> GetTrailersByMovieId(int movieId)
    {
        return _movieShopDbContext.Set<Trailers>().Where(trailers => trailers.MovieId == movieId).ToList();
    }
}