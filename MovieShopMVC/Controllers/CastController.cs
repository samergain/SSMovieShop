using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        public IActionResult Details(int id)
        {
            var castDetails = _castService.GetCastDetails(id);
            return View(castDetails);
        }
    }
}
