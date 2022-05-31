using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<bool> AddMovieReview(ReviewRequestModel reviewRequest)
        {
            var review = new Review
            {
                UserId = reviewRequest.UserId,
                MovieId = reviewRequest.MovieId,
                ReviewText = reviewRequest.ReviewText,
                Rating = reviewRequest.Rating
            };
            var addReview = await _reviewRepository.AddMovieReview(review);
            if (addReview == 1)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteMovieReview(int userId, int movieId)
        {
            var delReview = await _reviewRepository.DeleteMovieReview(userId, movieId);
            if (delReview == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            var review = new Review
            {
                UserId = reviewRequest.UserId,
                MovieId = reviewRequest.MovieId,
                ReviewText = reviewRequest.ReviewText,
                Rating = reviewRequest.Rating
            };
            var updatedReview = await _reviewRepository.UpdateMovieReview(review);
            if (updatedReview == 1)
            {
                return true;
            }
            return false;
        }
    }
}
