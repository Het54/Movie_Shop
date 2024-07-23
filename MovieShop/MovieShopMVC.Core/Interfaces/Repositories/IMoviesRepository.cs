using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Interfaces;

public interface IMoviesRepository: IRepository<Movies>
{
    IEnumerable<Movies> GetHighestGrossingMovies();

    IEnumerable<Movies> GetMoviesWithGenres(int id);
    
}