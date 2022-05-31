using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
        Task<int> AddFavorite(int userId, int movieId);
        Task<int> RemoveFavorite(int userId, int movieId);
        Task<bool> FavoriteExists(int userId, int movieId);
    }
}
