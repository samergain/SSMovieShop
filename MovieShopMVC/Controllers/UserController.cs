using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        
        public async Task<IActionResult> Purchases()
        {
            //check if user is logged in (if not logged in -> redirect to login page)
            //get userId -> go to purchase table and get user's purchased movies
            //display as movie cards

            // Purchases are secured resource and to be accessed we should:
            // 1- var data = this.HttpContext.Request.Cookies["MovieShopAuthCookie"];
            // 2- decrypt the cookie and get the userid from claims and expiration time from the cookie 
            // 3- use the userid to go to db and get the movies purchased
            // the steps above are automatically done in asp.net core using middleware in program.cs

            // we can achieve the isLoggedIn using Filters
            //var isLoggedIn = this.HttpContext.User.Identity.IsAuthenticated;
            //if (!isLoggedIn)
            //{
            //    //redirect to login page
            //}
            //var userId = this.HttpContext.User.Claims.FirstOrDefault(x => x.ValueType == ClaimType.Identifiers)?.Value;
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //call userService -> getPurchasedMovies -> list<moviecards>
             
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            return View();
        }

        public async Task<IActionResult> Reviews()
        {
            return View();
        }
    }
}
