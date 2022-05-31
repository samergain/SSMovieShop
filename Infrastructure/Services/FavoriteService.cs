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
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        public async Task<bool> AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            var fav = await _favoriteRepository.AddFavorite(favoriteRequest.userId, favoriteRequest.movieId);
            if(fav == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            var fav = await _favoriteRepository.RemoveFavorite(favoriteRequest.userId, favoriteRequest.movieId);
            if (fav == 1)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> FavoriteExists(int userId, int movieId)
        {
            var res = await _favoriteRepository.FavoriteExists(userId, movieId);
            return res;

        }

        
    }
}
