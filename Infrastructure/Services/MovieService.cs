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
                    ProfilePath = cast.Cast.ProfilePath,
                    Character = cast.Cast.TmdbUrl

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

    }
}
