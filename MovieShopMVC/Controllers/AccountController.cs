using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

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
