using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Todo.Web.Clients.Inerfaces;
using Todo.Web.Models;

namespace Todo.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserClient _userClient;

        public LoginController(IUserClient userClient)
        {
            _userClient = userClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Name, Password")] LoginViewModel model)
        {
            var result = await _userClient.ValidatePassword(new Clients.Models.ValidatePasswordInputModel
            {
                Name = model.Name,
                Password = model.Password
            });

            if (!result)
            {
                ModelState.AddModelError("Password", "Invalid password"); 
                return View(model);
            }

            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaim(new Claim("name", model.Name));
            claimsIdentity.AddClaim(new Claim("role", "User"));
            var principal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction(
                nameof(HomeController.Index), 
                "Home");
        }
    }
}
