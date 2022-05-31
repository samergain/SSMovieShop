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
        private readonly IFavoriteService _favoriteService;
        private readonly IReviewService _reviewService;
       
        //favorites //reviews //purchases
        public UserController(IUserRepository userRepository, IUserService userService, IPurchaseService purchaseService, IFavoriteService favoriteService, IReviewService reviewService)
        {
            _userRepository = userRepository;
            _userService = userService;
            _purchaseService = purchaseService;
            _favoriteService = favoriteService;
            _reviewService = reviewService;
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

        [Route("favorite")]
        [HttpPost]
        public async Task<IActionResult> PostUserNewFavorite(FavoriteRequestModel favoriteRequest)
        {
            var fav = await _favoriteService.AddFavorite(favoriteRequest);
            if (fav)
            {
                return Ok(fav);
            }
            return BadRequest();
        }

        [Route("un-favorite")]
        [HttpDelete]
        public async Task<IActionResult> PostUserRemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            var fav = await _favoriteService.RemoveFavorite(favoriteRequest);
            if (fav)
            {
                return Ok(fav);
            }
            return BadRequest();
        }

        [Route("check-movie-favorite/{movieId}")]
        [HttpGet]
        public async Task<IActionResult> GetIsMovieFavorite(int userId, int movieId)
        {
            var result = await _favoriteService.FavoriteExists(userId, movieId);
            if(result == false)
            {
                return NotFound("Not found in Favorites");
            }
            return Ok(result);
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

        [Route("add-review")]
        [HttpPost]
        public async Task<IActionResult> PostMovieReview(ReviewRequestModel model)
        {
            var review = await _reviewService.AddMovieReview(model);
            if (review)
            {
                return Ok(review);
            }
            return BadRequest();
        }

        [Route("remove-review/{movieId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMovieReview(int userId, int movieId)
        {
            var review = await _reviewService.DeleteMovieReview(userId,movieId);
            if (review)
            {
                return Ok(review);
            }
            return BadRequest();
        }

        [Route("edit-review")]
        [HttpPut]
        public async Task<IActionResult> PutMovieReview(ReviewRequestModel model)
        {
            var review = await _reviewService.UpdateMovieReview(model);
            if (review)
            {
                return Ok(review);
            }
            return BadRequest();
        }
    }
}
