using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var casts = await _castService.GetAllCasts();
            if (casts == null)
            {
                return NotFound();
            }
            return Ok(casts);
        }
    }
}
