using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IReviewRepository
    {
        Task<int> AddMovieReview(Review review);
        Task<int> UpdateMovieReview(Review review);
        Task<int> DeleteMovieReview(int userId, int movieId);
    }
}
