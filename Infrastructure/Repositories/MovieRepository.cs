using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
        {

        }
        public async Task<List<Movie>> GetTop30GrossingMovies()
        {
            
            var movies = await _dbContext.Movies.OrderByDescending(x => x.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public override async Task<Movie> GetById(int id)
        {
            // we need to join Navigation properties
            // Include method in EF will enable us to join with related navigation proerties
            var movie = await _dbContext.Movies.Include(m => m.MoviesOfGenre).ThenInclude(m => m.Genre)
                .Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);
            // FirstOrDefault safest one
            // First throws ex when 0 records
            // SingleOrDefault good for 0 or 1
            // Single throw ex when no records found or when more than 1 record is found

            return movie;
        }
        public async Task<PagedResultSet<Movie>> GetAllMovies(int pageSize = 30, int pageNumber = 1)
        {
            var moviesCount = await _dbContext.Movies.CountAsync();
            if(moviesCount == 0)
            {
                throw new Exception("No Movies Found");
            }
            var movies = await _dbContext.Movies.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var pagedMovies = new PagedResultSet<Movie>(movies, pageNumber, pageSize, moviesCount);
            return pagedMovies;
        }
        public async Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            // get total movies count for that genre
            // select count(*) from MovieGenre mg where mg.genreId = 1
            var totalMoviesCountByGenre = await _dbContext.MovieGenre.Where(m => m.GenreId == genreId).CountAsync();
            // get the actual movies from MovieGenre and Movie table
            if(totalMoviesCountByGenre == 0)
            {
                throw new Exception("No Movies Found for that genre");
            }

            var movies = await _dbContext.MovieGenre.Where(g => g.GenreId == genreId).Include(m => m.Movie)
                        .OrderBy(m => m.MovieId)
                        //converting movies from a list of MovieGenre to a list of Movies
                        .Select(m => new Movie
                        {
                            Id = m.MovieId,
                            PosterUrl = m.Movie.PosterUrl,
                            Title = m.Movie.Title
                        })
                        .Skip((pageNumber -1)*pageSize).Take(pageSize).ToListAsync();

            var pagedMovies = new PagedResultSet<Movie>(movies, pageNumber, pageSize, totalMoviesCountByGenre);
            return pagedMovies;
        }

        public async Task<List<Movie>> GetTop30RatedMovies()
        {
            //var topRated = await _dbContext.Review.Include(r => r.Movie).GroupBy(r => r.MovieId)
            //    .OrderByDescending(r => r.Average(r => r.Rating))
            //    .Select(r => new Movie
            //                {
            //                    Id = r.Select(r => r.MovieId),
            //                    Title = r.Select(r =>r.Movie.Title),
            //                    PosterUrl = r.Select(r=>r.Movie.PosterUrl)
            //                }).ToListAsync();
            //return topRated;

            var movies = (from r in _dbContext.Review.Include(r => r.Movie)

                         group r by r.MovieId into mr

                         orderby mr.Average(r => r.Rating) descending
                         select new Movie
                         {
                             Id = mr.FirstOrDefault().Movie.Id,
                             Title = mr.FirstOrDefault().Movie.Title,
                             PosterUrl = mr.FirstOrDefault().Movie.PosterUrl
                         }).Take(30);
            var res = new List<Movie>();

             foreach (var m in movies)
            {
                res.Add(new Movie { Id = m.Id, Title = m.Title, PosterUrl = m.PosterUrl });
            }
            return res;
           

        }

        public async Task<PagedResultSet<Review>> GetTop30Reviews(int movieId, int pageSize = 30, int pageNumber = 1)
        {
            var totalMovieReviewsCount = await _dbContext.Review.Where(r => r.MovieId == movieId).CountAsync();
            if(totalMovieReviewsCount == 0)
            {
                throw new Exception("No reviews found");
            }
            var reviews = await _dbContext.Review.Include(r => r.Movie).Where(r => r.MovieId == movieId)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var pagedReviews = new PagedResultSet<Review>(reviews, pageNumber, pageSize, totalMovieReviewsCount);
            return pagedReviews;
        }
    }
}
