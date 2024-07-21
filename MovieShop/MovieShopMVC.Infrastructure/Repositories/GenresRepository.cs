using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class GenresRepository: BaseRepository<Genres>, IGenresRepository
{
    public GenresRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
    }
}