using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class UsersRepository: BaseRepository<Users>, IUsersRepository<Users>
{
    public UsersRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
    }
}