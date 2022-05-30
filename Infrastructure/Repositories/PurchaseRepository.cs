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
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Purchase> GetPurchaseDetails(int userId, int movieId)
        {
            var purchase = await _dbContext.Purchase.FindAsync(userId, movieId);

            if (purchase == null)
            {
                throw new Exception("Not Found!");
                
            }
            return purchase;
        }

        public async Task<bool> IsMoviePurchased(int movieId, int userId)
        {
            var purchase = await _dbContext.Purchase.FindAsync(userId, movieId);
            return purchase != null;
        }

        public async Task<Purchase> PurchaseMovie(PurchaseRequestModel entity)
        {
            var purchase = new Purchase
            {
                UserId = entity.UserId,
                MovieId = entity.MovieId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = entity.TotalPrice,
                PurchaseDateTime = DateTime.Now
                
            };


            try
            {
                await _dbContext.Purchase.AddAsync(purchase);
                await _dbContext.SaveChangesAsync();

                return purchase;
            }
            catch
            {
                throw new Exception("Purchase couldn't be processed!");

            }
        }
    }
}
