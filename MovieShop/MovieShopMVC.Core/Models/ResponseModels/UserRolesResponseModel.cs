using MovieShopMVC.Core.Entities;

namespace MovieShopMVC.Core.Models.ResponseModels;

public class UserRolesResponseModel
{
    public int RoleId { get; set; }
    public Roles Role { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
}