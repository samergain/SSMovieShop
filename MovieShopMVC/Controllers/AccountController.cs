using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Register(UserRegisterModel model)
        {
            //save received data in user table
            //passwords should always be hashed with Salt(salt is a unique randomly created string)
            // the Salt value should be stored in db. for login authentication we
            //      1- get the salt from db
            //      2- hash the salt
            //      3- hash the entered password and add the  hashed salt to it
            //      4- compare the hashed password stored in db to the entered password after hashing and adding salt

            // what's the difference between encryption and hashing?
            // encryption is two way encrypt and decrypt  vs.  hashing is one-way (we can't get the original value)
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            return View();
        }
      
    }
}
