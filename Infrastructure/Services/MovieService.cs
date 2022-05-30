using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<List<MovieCardModel>> GetTop30GrossingMovies()
        {
            // this method should call the movieRepository which in turn will get the data from the db
            // get the entity class data then map the entity to model class
            //var movieRepo = new MovieRepository();

            var movies = await _movieRepository.GetTop30GrossingMovies();
            if(movies == null)
            {
                return null;
            }
            var movieCards = new List<MovieCardModel>();
            
            foreach(var movie in movies)
            {
                movieCards.Add(new MovieCardModel
                {
                    Title = movie.Title,
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl
                });
            }
            return movieCards;
           
        }

        public async Task<MovieDetailsModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetById(id);
            if(movie == null)
            {
                return null;
            }
            var movieDetails = new MovieDetailsModel {
                Id = movie.Id,
                Title = movie.Title,
                Budget = movie.Budget,
                Overview = movie.Overview,
                PosterUrl= movie.PosterUrl,
                BackdropUrl= movie.BackdropUrl,
                Price = movie.Price,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate,
                Tagline = movie.Tagline,
                RunTime = movie.RunTime,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl
                };
            
            foreach(var genre in movie.MoviesOfGenre)
            {
                movieDetails.Genres.Add(new GenreModel
                {
                    Id = genre.GenreId,
                    Name = genre.Genre.Name
                });
            }
            foreach(var cast in movie.MovieCasts)
            {
                movieDetails.Casts.Add(new CastModel
                {
                    Id = cast.CastId,
                    Name = cast.Cast.Name,
                    ProfilePath = cast.Cast.ProfilePath

                });
            }
            foreach(var trailer in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerModel
                {
                    Id = trailer.Id,
                    Name = trailer.Name,
                    TrailerUrl = trailer.TrailerUrl
                });
            }

            return movieDetails;
        }

        public async Task<PagedResultSet<MovieCardModel>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var pagedMovies = await _movieRepository.GetMoviesByGenres(genreId, pageSize, pageNumber);
            if(pagedMovies == null)
            {
                return null;
            }
            var movieCards = new List<MovieCardModel>();
            movieCards.AddRange(pagedMovies.Data.Select(m => new MovieCardModel
            {
                Id = m.Id,
                PosterUrl = m.PosterUrl,
                Title = m.Title
            }));

            return new PagedResultSet<MovieCardModel>(movieCards, pageNumber, pageSize, pagedMovies.Count);
        }

        public async Task<PagedResultSet<ReviewDetailsModel>> GetTop30Reviews(int movieId, int pageSize = 30, int pageNumber = 1)
        {
            var top30Reviews = await _movieRepository.GetTop30Reviews(movieId, pageSize, pageNumber); 
            if(top30Reviews == null)
            {
                return null;
            }
            var reviews = new List<ReviewDetailsModel>();
            foreach(var review in top30Reviews.Data)
            {
                
                reviews.Add(new ReviewDetailsModel
                {
                    MovieId = review.MovieId,
                    UserId = review.UserId,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText
                });
            }
            return new PagedResultSet<ReviewDetailsModel>(reviews, pageNumber, pageSize, reviews.Count);
        }

        public async Task<PagedResultSet<MovieCardModel>> GetAllMovies(int pageSize = 30, int pageNumber = 1)
        {
            var movies = await _movieRepository.GetAllMovies(pageSize, pageNumber);
            if(movies == null)
            {
                return null;
            }

            var moviesCards = new List<MovieCardModel>();
            moviesCards.AddRange(movies.Data.Select(m => new MovieCardModel
            {
                Id = m.Id,
                PosterUrl = m.PosterUrl,
                Title = m.Title
            }));
            return new PagedResultSet<MovieCardModel>(moviesCards, pageNumber, pageSize, movies.Count);
        }

        public async Task<List<MovieCardModel>> GetTopRatedMovies()
        {
            var topRatedMovies = await _movieRepository.GetTop30RatedMovies();
            var topRatedMoviesCards = new List<MovieCardModel>();
            foreach (var movie in topRatedMovies)
            {
                topRatedMoviesCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return topRatedMoviesCards;

        }
    }
}
