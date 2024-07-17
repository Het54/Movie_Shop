namespace MovieShopMVC.Core.Interfaces;

public interface IRepository<T> where T: class
{
    int Insert(T obj);
    int DeleteById(int id);
    int Update(T obj);
    T GetById(int id);
    IEnumerable<T> GetAll();
}