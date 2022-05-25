using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<List<Movie>> GetTop30GrossingMovies();

        //we need to return totalCount of movies, pagesize, pagenumber, and TotalPages
        // to return multiple objects we can:
        // 1- create a class PagedModel that contains all those objects
        // 2- return Tuple: tuple is a data structure which gives you the easiest way to represent a data set which has multiple values that may/may not be related to each other. 
        // Task<(IEnumerable<Movie>, int totalCount, int TotalPages)> GetMoviesByGenres(int genreId, int pageSize = 30, int pageNumber = 1);

        
        Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize = 30, int pageNumber = 1);
    }
}
