using AutoMapper;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.main.Utility;

public class ApplicationMapper: Profile
{
    public ApplicationMapper()
    {
        CreateMap<Movies, MoviesRequestModel>();
        CreateMap<MoviesRequestModel, Movies>();
        CreateMap<Movies, MoviesResponseModel>();
    }
}