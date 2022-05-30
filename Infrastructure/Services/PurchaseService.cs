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
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<Purchase> GetPurchaseDetails(int userId, int movieId)
        {
            var purchaseDetails = await _purchaseRepository.GetPurchaseDetails(userId, movieId);
            return purchaseDetails;
        }

        public async Task<bool> IsMoviePurchased(int movieId, int userId)
        {
            return await _purchaseRepository.IsMoviePurchased(userId, movieId);
        }

        public async Task<Purchase> PurchaseMovie(PurchaseRequestModel entity)
        {
            var purchase = await _purchaseRepository.PurchaseMovie(entity);
            return purchase;
        }
    }
}
