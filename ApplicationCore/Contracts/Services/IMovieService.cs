using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        // to be called by home/index action method
        Task<List<MovieCardModel>> GetTop30GrossingMovies();

        Task<MovieDetailsModel> GetMovieDetails(int id);
        Task<PagedResultSet<MovieCardModel>> GetAllMovies(int pageSize, int pageNumber);
        Task<PagedResultSet<MovieCardModel>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int pageNumber = 1);
        Task<List<MovieCardModel>> GetTopRatedMovies();
        Task<PagedResultSet<ReviewDetailsModel>> GetTop30Reviews(int movieId, int pageSize = 30, int pageNumber = 1);
        
    }
}
