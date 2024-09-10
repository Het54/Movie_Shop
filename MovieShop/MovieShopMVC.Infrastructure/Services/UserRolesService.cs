using AutoMapper;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Infrastructure.Services;

public class UserRolesService: IUserRolesService
{
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly IMapper _mapper;

    public UserRolesService(IUserRolesRepository userRolesRepository, IMapper mapper)
    {
        _userRolesRepository = userRolesRepository;
        _mapper = mapper;
    }


    public List<UserRolesResponseModel> GetAll()
    {
        var users = _userRolesRepository.GetAllUsersWithRoles();
        var userRolesResponseModel = new List<UserRolesResponseModel>();
        foreach (var user in users)
        {
            userRolesResponseModel.Add(_mapper.Map<UserRolesResponseModel>(user));
        }

        return userRolesResponseModel;
    }

    public int Add(UserRolesRequestModel model)
    {
        return _userRolesRepository.Insert(_mapper.Map<UserRoles>(model));
    }
}