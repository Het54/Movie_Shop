using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;
using MovieShopMVC.Infrastructure.Repositories;

namespace MovieShopMVC.Infrastructure.Services;

public class MoviesService: IMoviesService
{
    private readonly MoviesRepository _moviesRepository;

    public MoviesService(MoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }
    
    public List<MoviesResponseModel> GetAll()
    {
        var movies = _moviesRepository.GetAll();
        var moviesResponseModel = new List<MoviesResponseModel>();
        foreach (var movie in movies)
        {
            moviesResponseModel.Add(new MoviesResponseModel()
            {
                BackdropUrl = movie.BackdropUrl,
                Budget = movie.Budget,
                CreatedBy = movie.CreatedBy,
                CreatedDate = movie.CreatedDate,
                ImdbUrl = movie.ImdbUrl,
                OriginalLanguage = movie.OriginalLanguage,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                Tagline = movie.Tagline,
                Title = movie.Title,
                TmdbUrl = movie.TmdbUrl,
                UpdatedBy = movie.UpdatedBy,
                UpdatedDate = movie.UpdatedDate
            });
        }

        return moviesResponseModel;
    }

    public MoviesResponseModel GetById(int id)
    {
        var movie = _moviesRepository.GetById(id);
        if (movie != null)
        {
            var movieResponseModel = new MoviesResponseModel()
            {
                BackdropUrl = movie.BackdropUrl,
                Budget = movie.Budget,
                CreatedBy = movie.CreatedBy,
                CreatedDate = movie.CreatedDate,
                ImdbUrl = movie.ImdbUrl,
                OriginalLanguage = movie.OriginalLanguage,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                Tagline = movie.Tagline,
                Title = movie.Title,
                TmdbUrl = movie.TmdbUrl,
                UpdatedBy = movie.UpdatedBy,
                UpdatedDate = movie.UpdatedDate
            };
            return movieResponseModel;
        }

        return null;
    }

    public int Add(MoviesRequestModel model)
    {
        var movieEntity = new Movies()
        {
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