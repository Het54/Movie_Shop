using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class UsersRepository: BaseRepository<Users>, IUsersRepository
{
    private readonly MovieShopDbContext _movieShopDbContext;

    public UsersRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }

    public int InsertUser(Users entity)
    {
        _movieShopDbContext.Set<Users>().Add(entity);
        _movieShopDbContext.SaveChanges();
        return (entity as dynamic).Id;
    }
}