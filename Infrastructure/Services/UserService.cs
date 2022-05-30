using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<MovieCardModel>> GetAllFavoritesForUser(int id)
        {
            var favoriteMovies = await _userRepository.GetAllFavoritesForUser(id);
            var moviesModels = new List<MovieCardModel>();
            foreach (var movie in favoriteMovies)
            {
                moviesModels.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return moviesModels;
        }

        public async Task<List<MovieCardModel>> GetAllPurchasesForUser(int id)
        {
            var purchasedMovies = await _userRepository.GetPurchasesByUserId(id);
            var moviesModels = new List<MovieCardModel>();
            foreach(var movie in purchasedMovies)
            {
                moviesModels.Add(new MovieCardModel
                {
                    Id=movie.Id,
                    Title =movie.Title,
                    PosterUrl =movie.PosterUrl
                });
            }
            return moviesModels;
        }

        public async Task<List<ReviewDetailsModel>> GetAllReviewsByUser(int id)
        {
            var reviews = await _userRepository.GetAllReviewsByUser(id);
            var reviewsModels = new List<ReviewDetailsModel>();
            foreach(var review in reviews)
            {
                reviewsModels.Add(new ReviewDetailsModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating
                });
            }

            return reviewsModels;
        }
    }
}
