using Soft.Bussiness.Models.Users;
using System.Linq;
using System.Web.Http;

public class AccountController : ApiController
{
    private ApplicationDbContext db = new ApplicationDbContext();

    [HttpPost]
    [Route("api/account/login")]
    public IHttpActionResult Login(LoginModel loginModel)
    {
        

        var user = db.Users.FirstOrDefault(u => u.Username == loginModel.Username && u.Password == loginModel.Password);
       
        return Ok(new { Message = "Login successful" });
    }

}
