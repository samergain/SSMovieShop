using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null) return null;
            return user;
        }

        public override async Task<User> GetById(int id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null) return null;
            return user as User;
        }

        public async Task<List<Movie>> GetAllFavoritesForUser(int id)
        {
            var movies = await _dbContext.Favorite.Where(f => f.UserId == id).Include(m => m.Movie).OrderBy(m => m.Id)
                .Select( m => new Movie
                {
                    Id = m.MovieId,
                    PosterUrl = m.Movie.PosterUrl,
                    Title = m.Movie.Title
                })
                .ToListAsync();
            return movies;
               
        }

        public async Task<List<Review>> GetAllReviewsByUser(int id)
        {
            var reviews = await _dbContext.Review.Where(r => r.UserId == id).ToListAsync();
            return reviews;
        }

        public async Task<List<Movie>> GetPurchasesByUserId(int id)
        {
            var movies = await _dbContext.Purchase.Where(f => f.UserId == id).Include(m => m.Movie).OrderBy(m => m.Id)
                .Select(m => new Movie
                {
                    Id = m.MovieId,
                    PosterUrl = m.Movie.PosterUrl,
                    Title = m.Movie.Title
                })
                .ToListAsync();
            return movies;
        }
    }
}
