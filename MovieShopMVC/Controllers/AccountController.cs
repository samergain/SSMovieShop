using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            //save received data in user table
            //passwords should always be hashed with Salt(salt is a unique randomly created string)
            // the Salt value should be stored in db. 

            // what's the difference between encryption and hashing?
            // encryption is two way encrypt and decrypt  vs.  hashing is one-way (we can't get the original value)
            try
            {
                var user = await _accountService.RegisterUser(model);
            } 
            catch (ConflictException)
            {
                throw;
                //todo: logging exception
            }

            
            return RedirectToAction("Login");
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            try
            {
                var user = await _accountService.LoginUser(model.Email, model.Password);
                if(user != null)
                {
                    //claims are things that represent the user just like a personal ID
                    //claims are used to get access to special resources (pages)
                    //claim called Admin Role to enter admin page
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim("Language", "English") //custom claim
                    };

                    // Identity
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // create the cookie with the claims defined above
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    //we still need to define the cookie name and expiration date which is done globally in program.cs

                    //redirect to homepage
                    return LocalRedirect("~/");
                }
            }
            catch
            {
                return View();
                throw;
            }
            return View();
        }
      
    }
}
