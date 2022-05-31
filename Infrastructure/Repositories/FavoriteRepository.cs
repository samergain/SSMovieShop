using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> AddFavorite(int userId, int movieId)
        {
            var newFavorite = new Favorite { Id = userId, MovieId = movieId };
            try
            {
                await _dbContext.Favorite.AddAsync(newFavorite);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> FavoriteExists(int userId, int movieId)
        {
            var check = await _dbContext.Favorite.FindAsync(userId, movieId);
            return check != null;
        }

        public async Task<int> RemoveFavorite(int userId, int movieId)
        {
            try
            {
                var fav = await _dbContext.Favorite.FindAsync(userId, movieId);
                if (fav != null)
                {
                    _dbContext.Favorite.Remove(fav);
                    await _dbContext.SaveChangesAsync();
                    
                }
                return 1;

            }
            catch
            {
                return 0;
            }

        }
    }
}