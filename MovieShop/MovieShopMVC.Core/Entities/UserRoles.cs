using System.ComponentModel.DataAnnotations;

namespace MovieShopMVC.Core.Entities;

public class UserRoles
{
    public int RoleId { get; set; }
    public Roles Role { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
}