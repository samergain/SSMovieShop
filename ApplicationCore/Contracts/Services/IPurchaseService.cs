using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IPurchaseService
    {
        Task<Purchase> GetPurchaseDetails(int userId, int movieId);
        Task<bool> IsMoviePurchased(int movieId, int userId);
        Task<Purchase> PurchaseMovie(PurchaseRequestModel entity);
    }
}
