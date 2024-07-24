using AutoMapper;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;
using MovieShopMVC.Infrastructure.Repositories;

namespace MovieShopMVC.Infrastructure.Services;

public class MoviesService: IMoviesService
{
    private readonly IMoviesRepository _moviesRepository;
    private readonly IMapper _mapper;

    public MoviesService(IMoviesRepository moviesRepository, IMapper mapper)
    {
        _moviesRepository = moviesRepository;
        _mapper = mapper;
    }
    
    public List<MoviesResponseModel> GetAll()
    {
        var movies = _moviesRepository.GetAll();
        var moviesResponseModel = new List<MoviesResponseModel>();
        foreach (var movie in movies)
        {
            moviesResponseModel.Add(_mapper.Map<MoviesResponseModel>(movie));
        }
        return moviesResponseModel;
    }

    public List<MoviesResponseModel> GetMoviesByPages(int pageNumber)
    {
        var movies = _moviesRepository.GetAll().Skip((pageNumber - 1) * 18).Take(18).ToList();
        var moviesResponseModel = new List<MoviesResponseModel>();
        foreach (var movie in movies)
        {
            moviesResponseModel.Add(_mapper.Map<MoviesResponseModel>(movie));
        }

        return moviesResponseModel;
    }


    public MoviesResponseModel GetById(int id)
    {
        var movie = _moviesRepository.GetById(id);
        if (movie != null)
        {
            var movieResponseModel = _mapper.Map<MoviesResponseModel>(movie);
            return movieResponseModel;
        }

        return null;
    }

    public List<MoviesResponseModel> GetHighestGrossingMovies()
    {
        var movies = _moviesRepository.GetHighestGrossingMovies();
        var moviesResponseModel = new List<MoviesResponseModel>();
        foreach (var movie in movies)
        {
            moviesResponseModel.Add(_mapper.Map<MoviesResponseModel>(movie));
        }
        return moviesResponseModel;
    }

    public List<MoviesResponseModel> GetMoviesWithGenresByPages(int id, int pageNumber)
    {
        var moviesWithGenres = _moviesRepository.GetMoviesWithGenres(id).Skip((pageNumber - 1) * 18).Take(18).ToList();
        var moviesResponseModel = new List<MoviesResponseModel>();
        foreach (var movie in moviesWithGenres)
        {
            moviesResponseModel.Add(_mapper.Map<MoviesResponseModel>(movie));
        }

        return moviesResponseModel;
    }
    
    public List<MoviesResponseModel> GetMoviesWithGenres(int id)
    {
        var moviesWithGenres = _moviesRepository.GetMoviesWithGenres(id).ToList();
        var moviesResponseModel = new List<MoviesResponseModel>();
        foreach (var movie in moviesWithGenres)
        {
            moviesResponseModel.Add(_mapper.Map<MoviesResponseModel>(movie));
        }

        return moviesResponseModel;
    }

    public int Add(MoviesRequestModel model)
    {
        
        var movieEntity = _mapper.Map<Movies>(model);
        return _moviesRepository.Insert(movieEntity);
    }

    public int DeleteById(int id)
    {
        return _moviesRepository.DeleteById(id);
    }

    public int Update(int id, MoviesRequestModel model)
    {
        var movieEntity = new Movies()
        {
            Id = id,
            BackdropUrl = model.BackdropUrl,
            Budget = model.Budget,
            CreatedBy = model.CreatedBy,
            CreatedDate = model.CreatedDate,
            ImdbUrl = model.ImdbUrl,
            OriginalLanguage = model.OriginalLanguage,
            Overview = model.Overview,
            PosterUrl = model.PosterUrl,
            Price = model.Price,
            ReleaseDate = model.ReleaseDate,
            Revenue = model.Revenue,
            Runtime = model.Runtime,
            Tagline = model.Tagline,
            Title = model.Title,
            TmdbUrl = model.TmdbUrl,
            UpdatedBy = model.UpdatedBy,
            UpdatedDate = model.UpdatedDate
        };
        return _moviesRepository.Update(movieEntity);
    }
    
}