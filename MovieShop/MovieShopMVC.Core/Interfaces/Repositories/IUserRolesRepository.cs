using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Interfaces;

public interface IUserRolesRepository:IRepository<UserRoles>
{
    IEnumerable<UserRoles> GetAllUsersWithRoles();
}