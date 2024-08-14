using Soft.Api.ViewModel;
using Soft.Bussiness.Core.Services;
using Soft.Bussiness.Models.Books;
using Soft.Bussiness.Models.Users;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

public class LoginController : Controller
{
    private readonly IUserServices _userService;

    public LoginController(IUserServices userService)
    {
        _userService = userService;
    }

    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(UserViewModel user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }
        var userMapped = new User
        {
            Username = user.Username,
            Password = user.Password
        };

         var result = await _userService.GetUserAsync(userMapped);
            if (result != null)
            Session["JWTToken"] = result;
        return RedirectToAction("Index", "Home"); 
           
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(user);
    }

    public ActionResult Logout()
    {
        Session.Clear();
        Session.Abandon();

        return RedirectToAction("Login", "Login");
    }
}
