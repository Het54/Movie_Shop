using Microsoft.EntityFrameworkCore;
using Moq;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Infrastructure.Data;
using MovieShopMVC.Infrastructure.Repositories;

namespace MovieShop.UnitTest;

[TestClass]
public class MoviesRepositoryUnitTest
{

    private MoviesRepository _sut;
    private Mock<MovieShopDbContext> _dbContextMock;

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<MovieShopDbContext>()
            .UseInMemoryDatabase(databaseName: "testDatabase")
            .Options;

        _dbContextMock = new Mock<MovieShopDbContext>(options);
        
        //mocking DbSet
        var mockDbSet = new Mock<DbSet<Movies>>();
        
        //Setting for Set<T>
        _dbContextMock.Setup(c => c.Set<Movies>()).Returns(mockDbSet.Object);
        
        _sut = new MoviesRepository(_dbContextMock.Object);


    }


    [TestMethod]
    public void GetById_Returns_Category()
    {
        _dbContextMock.Setup(x => x.Set<Movies>().Find(1))
            .Returns(new Movies
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

        var result = _sut.GetById(1);
        
        Assert.IsNotNull(result);
    }


}