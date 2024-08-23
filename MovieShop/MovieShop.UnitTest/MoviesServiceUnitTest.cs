using AutoMapper;
using Moq;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;
using MovieShopMVC.Infrastructure.Services;

namespace MovieShop.UnitTest;

[TestClass]
public class MoviesServiceUnitTest
{
    private MoviesService _sut;
    private IMapper mapper;
    private Mock<IMoviesRepository> _mockMoviesRepository;

    [TestInitialize]
    public void Setup()
    {
        //Arrange
        _mockMoviesRepository = new Mock<IMoviesRepository>();
        _sut = new MoviesService(_mockMoviesRepository.Object, mapper);
    }
    
    [TestMethod]
    public void TestOf_GetAll_Returns_MoviesResponseModel()
    {
        //MoviesService.cs ==> GetAll()
        //System Under Test: SUT

        var _movies = new List<Movies>()
        {
            new Movies
            {
                Id = 1, BackdropUrl = "https://image.tmdb.org/t/p/original//s3TBrRGB1iav7gFOCNx3H31MoES.jpg",
                Budget = 160000000, ImdbUrl = "https://www.imdb.com/title/tt1375666", OriginalLanguage = "en",
                Overview =
                    "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: \"inception\", the implantation of another person's idea into a target's subconscious.",
                PosterUrl = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
                ReleaseDate = new DateTime(2010, 07, 15), Revenue = 825532764, Runtime = 148,
                Tagline = "Your mind is the scene of the crime.", Title = "Inception",
                TmdbUrl = "https://www.themoviedb.org/movie/27205"
            },
            new Movies
            {
                Id = 2, BackdropUrl = "https://image.tmdb.org/t/p/original//xJHokMbljvjADYdit5fK5VQsXEG.jpg",
                Budget = 165000000, ImdbUrl = "https://www.imdb.com/title/tt0816692", OriginalLanguage = "en",
                Overview =
                    "The adventures of a group of explorers who make use of a newly discovered wormhole to surpass the limitations on human space travel and conquer the vast distances involved in an interstellar voyage.",
                PosterUrl = "https://image.tmdb.org/t/p/w342//gEU2QniE6E77NI6lCU6MxlNBvIx.jpg",
                ReleaseDate = new DateTime(2014, 11, 5), Revenue = 675120017, Runtime = 169,
                Tagline = "Mankind was born on Earth. It was never meant to die here.", Title = "Interstellar",
                TmdbUrl = "https://www.themoviedb.org/movie/157336"
            }
        };
        
        //Arrange
        _mockMoviesRepository.Setup(x => x.GetAll()).Returns(_movies);
        
        //Act
        var movies = _sut.GetAll();
        
        //Assert
        Assert.IsNotNull(movies);
        Assert.IsInstanceOfType(movies, typeof(List<MoviesResponseModel>));
        Assert.AreEqual(2, movies.Count);
        
    }


    [TestMethod]
    public void TestOf_DeleteById_Returns_Integer()
    {
        //Arrange
        _mockMoviesRepository.Setup(x=>x.GetById(It.IsAny<int>())).Returns(new Movies()
        {
            Id = 1, BackdropUrl = "https://image.tmdb.org/t/p/original//s3TBrRGB1iav7gFOCNx3H31MoES.jpg",
            Budget = 160000000, ImdbUrl = "https://www.imdb.com/title/tt1375666", OriginalLanguage = "en",
            Overview =
                "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: \"inception\", the implantation of another person's idea into a target's subconscious.",
            PosterUrl = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
            ReleaseDate = new DateTime(2010, 07, 15), Revenue = 825532764, Runtime = 148,
            Tagline = "Your mind is the scene of the crime.", Title = "Inception",
            TmdbUrl = "https://www.themoviedb.org/movie/27205"
        });

        _mockMoviesRepository.Setup(x => x.DeleteById(It.IsAny<int>())).Returns(1);
        
        
        //Act
        var response = _sut.DeleteById(2);
        
        //Assert
        Assert.IsNotNull(response);
        Assert.AreEqual(1, response);
        _mockMoviesRepository.Verify(x=>x.DeleteById(It.IsAny<int>()), Times.Once);
    }

    [TestMethod]
    public void TestOf_DeleteById_Throws_Exception()
    {
        //Arrange 
        int MovieThatDoesNotExist = 23412345;
        Movies movies = null;

        _mockMoviesRepository.Setup(x => x.GetById(MovieThatDoesNotExist)).Returns(movies);
    
        //Assert & Act
        Assert.ThrowsException<Exception>(() =>
        {
            return _sut.DeleteById(MovieThatDoesNotExist);
        });
    }

    [TestMethod]
    public void TestOf_GetById_Returns_MovieResponseModel()
    {
        
        //Arrange
        _mockMoviesRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Movies
        {
            Id = 1, BackdropUrl = "https://image.tmdb.org/t/p/original//s3TBrRGB1iav7gFOCNx3H31MoES.jpg",
            Budget = 160000000, ImdbUrl = "https://www.imdb.com/title/tt1375666", OriginalLanguage = "en",
            Overview =
                "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: \"inception\", the implantation of another person's idea into a target's subconscious.",
            PosterUrl = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
            ReleaseDate = new DateTime(2010, 07, 15), Revenue = 825532764, Runtime = 148,
            Tagline = "Your mind is the scene of the crime.", Title = "Inception",
            TmdbUrl = "https://www.themoviedb.org/movie/27205"
        }); 
        
        //Act
        var response = _sut.GetById(1);
        
        //Assert
        Assert.IsInstanceOfType(response, typeof(MoviesResponseModel));
        Assert.IsNotNull(response);
    }
    
    [TestMethod]
    public void TestOf_GetById_ReturnsNull()
    {
        Movies movies = null;
        
        //Arrange
        _mockMoviesRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(movies); 
        
        //Act
        var response = _sut.GetById(1);
        
        //Assert
        Assert.IsNull(response);
    }

    // [TestMethod]
    // public void TestOf_Add_ReturnsInteger()
    // {
    //     //Arrange
    //     _mockMoviesRepository.Setup(x => x.Insert(It.IsAny<Movies>())).Returns(It.IsAny<int>());
    //     
    //     //Act
    //     var response = _sut.Add(new MoviesRequestModel()
    //     {
    //         Budget = 160000000, ImdbUrl = "https://www.imdb.com/title/tt1375666", OriginalLanguage = "en",
    //         Overview =
    //             "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: \"inception\", the implantation of another person's idea into a target's subconscious.",
    //         PosterUrl = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
    //         ReleaseDate = new DateTime(2010, 07, 15), Revenue = 825532764, Runtime = 148,
    //         Tagline = "Your mind is the scene of the crime.", Title = "Inception",
    //         TmdbUrl = "https://www.themoviedb.org/movie/27205"
    //     });
    //     
    //     
    //     //Assert
    //     Assert.IsNotNull(response);
    //     Assert.IsInstanceOfType(response, typeof(int));
    // }
    
    
    [DataTestMethod]
    [DataRow("http")]
    [DataRow("httpsssss")]
    public void TestOf_Add_ReturnsInteger(string imdburl)
    {
        //Arrange
        _mockMoviesRepository.Setup(x => x.Insert(It.IsAny<Movies>())).Returns(It.IsAny<int>());
        
        //Act
        var response = _sut.Add(new MoviesRequestModel()
        {
            Budget = 160000000, ImdbUrl = imdburl, OriginalLanguage = "en",
            Overview =
                "Cobb, a skilled thief who commits corporate espionage by infiltrating the subconscious of his targets is offered a chance to regain his old life as payment for a task considered to be impossible: \"inception\", the implantation of another person's idea into a target's subconscious.",
            PosterUrl = "https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg",
            ReleaseDate = new DateTime(2010, 07, 15), Revenue = 825532764, Runtime = 148,
            Tagline = "Your mind is the scene of the crime.", Title = "Inception",
            TmdbUrl = "https://www.themoviedb.org/movie/27205"
        });
        
        
        //Assert
        Assert.IsNotNull(response);
        Assert.IsInstanceOfType(response, typeof(int));
    }


    [TestMethod]
    public void TestOf_Add_ThrowsWxception()
    {
        //Arrange
        MoviesRequestModel moviesRequestModel = null;
        
        //Assert & Act 
        Assert.ThrowsException<ArgumentException>(() =>
        {
            return _sut.Add(moviesRequestModel);
        });
    }
    
}
