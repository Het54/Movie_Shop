using AutoMapper;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.main.Utility;

public class ApplicationMapper: Profile
{
    public ApplicationMapper()
    {
        CreateMap<Movies, MoviesRequestModel>().ReverseMap();
        CreateMap<Movies, MoviesResponseModel>().ReverseMap();
        CreateMap<Users, UsersRequestModel>().ReverseMap();
        CreateMap<Users, UsersResponseModel>().ReverseMap();
        CreateMap<UserRoles, UserRolesResponseModel>().ReverseMap();
        CreateMap<UserRoles, UserRolesRequestModel>().ReverseMap();
    }
}