using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Interfaces;

public interface ITrailersRepository: IRepository<Trailers>
{
    List<Trailers> GetTrailersByMovieId(int movieId);
}