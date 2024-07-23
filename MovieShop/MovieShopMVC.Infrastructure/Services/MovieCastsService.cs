using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;

namespace MovieShopMVC.Infrastructure.Services;

public class MovieCastsService: IMovieCastsService
{
    private readonly IMovieCastsRepository _movieCastsRepository;

    public MovieCastsService(IMovieCastsRepository movieCastsRepository)
    {
        _movieCastsRepository = movieCastsRepository;
    }
    public List<MovieCasts> GetByMovieId(int movieid)
    {
        return _movieCastsRepository.GetCastsByMovieId(movieid);
    }

    public List<MovieCasts> GetMoviesByCastId(int castId)
    {
        return _movieCastsRepository.GetMoviesByCastId(castId);
    }
}