using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        //---------------------------Purchase-----------------------------------//
        //Task PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        //Task IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId);
        Task<List<MovieCardModel>> GetAllPurchasesForUser(int id);
        Task<PurchaseDetailsModel> GetPurchaseDetails(int userId, int movieId);

        //---------------------------Favorite--------------------------------------//
        //Task AddFavorite(FavoriteRequestModel favoriteRequest);
        //Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
        //Task FavoriteExists(int id, int movieId);
        Task<List<MovieCardModel>> GetAllFavoritesForUser(int id);

        //---------------------------Review--------------------------------------//
        //Task AddMovieReview(ReviewRequestModel reviewRequest);
        //Task UpdateMovieReview(ReviewRequestModel reviewRequest);
        //Task DeleteMovieReview(int userId, int movieId);
        //Task GetAllReviewsByUser(int id);
        //--------------------------------------------------------------------------//


    }
}
