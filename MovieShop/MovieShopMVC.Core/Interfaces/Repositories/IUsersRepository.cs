using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Interfaces;

public interface IUsersRepository: IRepository<Users>
{
    int InsertUser(Users entity);
}