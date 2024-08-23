using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MovieShopMVC.Core.Interfaces.Services;
using MovieShopMVC.main.JWTAuthenticationManager.Models.RequestModel;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MovieShopMVC.main.JWTAuthenticationManager;

public class JWTTokenHandler
{
    private readonly IUserRolesService _userRolesService;
    public const string JWT_SECURITY_KEY = "jvsdYEVckwHJSjklnJBjsuJBeuwhIOJj1y43gfvhj234vyu2y34vfhj2b";
    private const int JWT_TOKEN_VALIDITY_MINS = 20;

    public JWTTokenHandler(IUserRolesService userRolesService)
    {
        _userRolesService = userRolesService;
    }

    public AuthenticationResponseModel GenerateToken(AuthenticationRequestModel model)
    {
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.HashedPassword))
        {
            return null;
        }
        
        var users = _userRolesService.GetAll()
            .Where(x => x.User.Email == model.Email && x.User.HashedPassword == model.HashedPassword).ToList();
        
        if (users.IsNullOrEmpty())
        {
            return null;
        }

        Console.WriteLine(users[0].User.Email);
        Console.WriteLine(users[0].Role.Name);
    
        var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, users[0].User.Email),
            new Claim(ClaimTypes.Role, users[0].Role.Name)
        });
        
        var signingCredential =
            new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);
        
        //Token Descriptor
        var securityTokenDescriptor = new SecurityTokenDescriptor();
        securityTokenDescriptor.Subject = claimsIdentity;
        securityTokenDescriptor.Expires = tokenExpiryTimeStamp;
        securityTokenDescriptor.SigningCredentials = signingCredential;
        securityTokenDescriptor.NotBefore = DateTime.Now;
        
        //TokenHandler to create a Token
        var securityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = securityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = securityTokenHandler.WriteToken(securityToken);
        
        return new AuthenticationResponseModel
        {
            Email = users[0].User.Email,
            ExpireIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
            JwtToken = token
        };
    }
}