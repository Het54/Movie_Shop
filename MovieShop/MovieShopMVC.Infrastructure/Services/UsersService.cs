using MovieShopMVC.Core.Entities;
using MovieShopMVC.Core.Interfaces;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.Core.Models.RequestModels;
using MovieShopMVC.Core.Models.ResponseModels;

namespace MovieShopMVC.Infrastructure.Services;

public class UsersService: IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public List<UsersResponseModel> GetAll()
    {
        var users = _usersRepository.GetAll();
        var usersResponseModel = new List<UsersResponseModel>();
        foreach (var user in users)
        {
            usersResponseModel.Add(new UsersResponseModel()
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ProfilePictureUrl = user.ProfilePictureUrl
            });
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
        var userEntity = new Users()
        {
            DateOfBirth = model.DateOfBirth,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            ProfilePictureUrl = model.ProfilePictureUrl
            //Need to implement the logic for password and profilepicurl
        };
        return _usersRepository.Insert(userEntity);
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