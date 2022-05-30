using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
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
        private readonly IPurchaseService _purchaseService;
       
        //favorites //reviews //purchases
        public UserController(IUserRepository userRepository, IUserService userService, IPurchaseService purchaseService)
        {
            _userRepository = userRepository;
            _userService = userService;
            _purchaseService = purchaseService;
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

        [Route("purchase-movie")]
        [HttpPost]
        public async Task<IActionResult> PostUserMoviePurchase(PurchaseRequestModel entity)
        {
            var purchase = await _purchaseService.PurchaseMovie(entity);
            if (purchase == null)
            {
                return BadRequest("Couldn't Complete Purchase");
            }
            return Ok(purchase);
        }

        [Route("purchase-details/{movieId}")]
        [HttpGet]
        public async Task<IActionResult> GetPurchaseDetails(int userId, int movieId)
        {
            var purchase = await _purchaseService.GetPurchaseDetails(userId, movieId);
            if (purchase == null)
            {
                return NotFound("Movie is not purchased");
            }
            return Ok(purchase);
        }

        [Route("check-movie-purchase/{movieId}")]
        [HttpGet]
        public async Task<IActionResult> GetIsMoviePurchased(int userId, int movieId)
        {
            bool result = await _purchaseService.IsMoviePurchased(userId, movieId);
            if (!result)
            {
                return NotFound("Movie is not purchased");
            }
            return Ok(result);

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
