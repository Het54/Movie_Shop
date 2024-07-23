using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Interfaces.Services;

public interface ITrailersService
{
    List<Trailers> GetByMovieId(int movieid);
}