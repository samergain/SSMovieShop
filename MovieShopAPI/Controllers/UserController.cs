using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        //favorites //reviews //purchases
        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Route("favorites")]
        [HttpGet]
        public async Task<IActionResult> GetUserFavorites(int id)
        {
            var favorites = await _userService.GetAllFavoritesForUser(id);
            if(favorites == null)
            {
                return NotFound();

            }
            return Ok(favorites);
        }

        [Route("purchases")]
        [HttpGet]
        public async Task<IActionResult> GetUserPurchases(int id)
        {
            var purchases = await _userService.GetAllPurchasesForUser(id);
            if (purchases == null)
            {
                return NotFound();

            }
            return Ok(purchases);
        }

        [Route("reviews")]
        [HttpGet]
        public async Task<IActionResult> GetUserReviews(int id)
        {
            var reviews = await _userService.GetAllReviewsByUser(id);
            if (reviews == null)
            {
                return NotFound();

            }
            return Ok(reviews);
        }
    }
}
