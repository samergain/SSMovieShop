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
        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            // this method should call the movieRepository which in turn will get the data from the db
            // get the entity class data then map the entity to model class
            //var movieRepo = new MovieRepository();

            var movies = _movieRepository.GetTop30GrossingMovies();
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

        public MovieDetailsModel GetById(int id)
        {
            var movie = _movieRepository.GetById(id);
            var movieDetails = new MovieDetailsModel();
            movieDetails.Id = id;
            movieDetails.Title = movie.Title;
            movieDetails.PosterUrl = movie.PosterUrl;
            movieDetails.BackdropUrl = movie.BackdropUrl;
            movieDetails.Overview = movie.Overview;
            movieDetails.Tagline = movie.Tagline;
            movieDetails.Budget = movie.Budget;
            movieDetails.Revenue = movie.Revenue;
            movieDetails.ImdbUrl = movie.ImdbUrl;
            movieDetails.TmdbUrl = movie.TmdbUrl;
            movieDetails.ReleaseDate = movie.ReleaseDate;
            movieDetails.RunTime = movie.RunTime;
            movieDetails.Price = movie.Price;
            //movieDetails.Genres = movie.MoviesOfGenre.ToArray();
            //movieDetails.Trailers = movie.Trailers.ToArray();
            //movieDetails.Casts = movie.MovieCasts.ToArray();

            return movieDetails;
        }

    }
}
