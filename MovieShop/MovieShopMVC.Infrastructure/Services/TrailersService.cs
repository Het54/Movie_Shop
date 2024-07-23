using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;

namespace MovieShopMVC.Infrastructure.Services;

public class TrailersService: ITrailersService
{
    private readonly ITrailersRepository _trailersRepository;

    public TrailersService(ITrailersRepository trailersRepository)
    {
        _trailersRepository = trailersRepository;
    }

    public List<Trailers> GetByMovieId(int movieid)
    {
        return _trailersRepository.GetTrailersByMovieId(movieid);
    }
}