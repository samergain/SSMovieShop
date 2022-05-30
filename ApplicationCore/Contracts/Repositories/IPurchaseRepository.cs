using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        Task<List<Movie>> GetPurchaseByUserId(int userId);
        Task<Purchase> GetPurchaseDetails(int userId, int movieId);

        Task<Purchase> PurchaseMovie (Purchase Entity);
        Task<bool> IsMoviePurchased(int movieId, int userId);
        
        
    }
}
