using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using Soft.Bussiness.Models.Books;
using Soft.Bussiness.Models.Users;
using Soft.Infra.Data.Repository;

public class AccountController : ApiController
{
    private ApplicationDbContext db = new ApplicationDbContext();
     private readonly IUserRepository _userRepository;
    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    [HttpPost]
    [Route("api/account/login")]
    public async Task<IHttpActionResult> Login(User loginModel)
    {

         var userx = await _userRepository.GetAll();

        // var user = loginModel.Username.ToString(); /*db.Users.FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);*/
        // Mocking a specific user for testing purposes
        var user = (loginModel.Username == "fred")
            ? new User { Username = "fred", Password = "123" }
            : null;
        if (user == null)
        {
            return Unauthorized();
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("s3gur1t33eyJw7S3c53tK3y-frederico-brit0-alves");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return Ok(new
        {
            Token = tokenString,
            Message = "Login successful"
        });
    }
}
