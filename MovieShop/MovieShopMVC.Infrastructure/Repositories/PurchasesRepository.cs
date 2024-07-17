using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class PurchasesRepository: BaseRepository<Purchases>, IPurchasesRepository<Purchases>
{
    public PurchasesRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
    }
}