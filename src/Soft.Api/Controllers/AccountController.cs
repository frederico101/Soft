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
   // private ApplicationDbContext db = new ApplicationDbContext();
     private readonly IUserRepository _userRepository;
     private readonly IBookRepository _bookRepository;
    public AccountController(IUserRepository userRepository, IBookRepository bookRepository)
    {
        _userRepository = userRepository;
        _bookRepository = bookRepository;
    }


    [HttpPost]
    [Route("api/account/login")]
    public async Task<IHttpActionResult> Login(User loginModel)
    {
        try
        {
            var userx = await _userRepository.GetAll();
            var user = userx.FirstOrDefault(x => x.Username == loginModel.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("s3gur1t33eyJw7S3c53tK3y-frederico-brit0-alves");
            var issuer = "https://myapp.example.com"; // Must match the issuer in Startup.cs
            var audience = "https://myapp.example.com"; // Must match the audience in Startup.cs

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
                Audience = audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Token = tokenString,
                Message = "Login successful"
            });
        }
        catch (Exception ex)
        {
            return Ok(new
            {
                Token = "",
                Message = "an invalid username or password"
            });
        }
    }
}
