using Microsoft.EntityFrameworkCore;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Infrastructure.Data;

namespace MovieShopMVC.Infrastructure.Repositories;

public class UserRolesRepository: BaseRepository<UserRoles>, IUserRolesRepository
{
    private readonly MovieShopDbContext _movieShopDbContext;

    public UserRolesRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }

    public IEnumerable<UserRoles> GetAllUsersWithRoles()
    {
        return _movieShopDbContext.Set<UserRoles>().Include(ur => ur.Role).Include(ur => ur.User).ToList();
    }
}