using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsModel> GetCastDetails(int id)
        {
            var cast = await _castRepository.GetById(id);

            var castDetails = new CastDetailsModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                ProfilePath = cast.ProfilePath,
                TmdbUrl = cast.TmdbUrl
            };

            foreach(var movie in cast.CastMovies)
            {
                castDetails.Movies.Add(new MovieCardModel
                {
                    Id = movie.MovieId,
                    Title = movie.Movie.Title,
                    PosterUrl = movie.Movie.PosterUrl
                });
            }

            return castDetails;
        }

        public async Task<List<CastModel>> GetAllCasts()
        {
            var casts = await _castRepository.GetAllCasts();
            var castsModels = new List<CastModel>();
            foreach (var cast in casts)
            {
                castsModels.Add(new CastModel
                {
                    Name = cast.Name,
                    Id = cast.Id,
                    ProfilePath = cast.ProfilePath

                });
            }
            return castsModels;

        }

       
    }

}
