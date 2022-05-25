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

        public Task<List<MovieCardModel>> GetAllFavoritesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieCardModel>> GetAllPurchasesForUser(int id)
        {
            var user = await _userRepository.GetById(id);
            var purchases = new List<MovieCardModel>();
            //get user.purchases and add them to purchases
            return purchases;
        }

        public Task<PurchaseDetailsModel> GetPurchaseDetails(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
