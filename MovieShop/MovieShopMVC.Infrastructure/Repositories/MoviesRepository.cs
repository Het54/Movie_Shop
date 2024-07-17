using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class MoviesRepository: BaseRepository<Movies>, IMoviesRepository<Movies>
{
    public MoviesRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
    }
}