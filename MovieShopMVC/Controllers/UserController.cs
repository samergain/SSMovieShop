using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            //check if user is logged in (if not logged in -> redirect to login page)
            //get userId -> go to purchase table and get user's purchased movies
            //display as movie cards
            return View();
        }

        public async Task<IActionResult> Favorites()
        {
            return View();
        }
    }
}
