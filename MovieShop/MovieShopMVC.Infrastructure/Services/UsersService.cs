using AutoMapper;
using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Infrastructure.Services;

public class UsersService: IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly IUserRolesService _userRolesService;

    public UsersService(IUsersRepository usersRepository, IMapper mapper, IUserRolesService userRolesService)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
        _userRolesService = userRolesService;
    }

    public List<UsersResponseModel> GetAll()
    {
        var users = _usersRepository.GetAll();
        var usersResponseModel = new List<UsersResponseModel>();
        foreach (var user in users)
        {
            usersResponseModel.Add(_mapper.Map<UsersResponseModel>(user));
        }
        return usersResponseModel;
    }

    public UsersResponseModel GetById(int id)
    {
        var user = _usersRepository.GetById(id);
        if (user != null)
        {
            var userResponseModel = new UsersResponseModel()
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ProfilePictureUrl = user.ProfilePictureUrl
            };
            return userResponseModel;
        }

        return null;
    }

    public int Add(UsersRequestModel model)
    {
        var id = _usersRepository.InsertUser(_mapper.Map<Users>(model));
        UserRolesRequestModel userRolesRequestModel = new UserRolesRequestModel()
        {
            RoleId = 2,
            UserId = id
        };
        return _userRolesService.Add(userRolesRequestModel);
    }

    public int DeleteById(int id)
    {
        return _usersRepository.DeleteById(id);
    }

    public int Update(int id, UsersRequestModel model)
    {
        var userEntity = new Users()
        {
            Id = id,
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            ProfilePictureUrl = model.ProfilePictureUrl
            //Need to implement the logic for password and profilepicurl
        };
        return _usersRepository.Update(userEntity);
    }
}