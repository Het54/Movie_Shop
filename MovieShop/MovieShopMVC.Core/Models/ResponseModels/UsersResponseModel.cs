namespace MovieShopMVC.Core.Models.ResponseModels;

public class UsersResponseModel
{
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string HashedPassword { get; set; }
}