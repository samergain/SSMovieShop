using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> AddMovieReview(Review review)
        {
            
            try
            {
                await _dbContext.Review.AddAsync(review);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> DeleteMovieReview(int userId, int movieId)
        {
            try
            {
                var r = await _dbContext.Review.FindAsync(userId, movieId);
                if (r != null)
                {
                    _dbContext.Review.Remove(r);
                    await _dbContext.SaveChangesAsync();

                }
                return 1;

            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> UpdateMovieReview(Review review)
        {
            try
            {
                _dbContext.Review.Update(review);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
