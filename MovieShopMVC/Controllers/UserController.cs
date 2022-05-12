using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
