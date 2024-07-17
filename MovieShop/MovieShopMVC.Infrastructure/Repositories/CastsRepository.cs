using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class CastsRepository: BaseRepository<Casts>, ICastsRepository<Casts>
{
    public CastsRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
    }
}