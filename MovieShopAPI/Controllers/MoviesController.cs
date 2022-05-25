using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;

namespace MovieShopAPI.Controllers
{
    //attribute-base routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //we need to call our service and repository using ctor ingect dependency
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //  api/movies/top-grossing
        [Route("top-grossing")]
        [HttpGet]
        public async Task<IActionResult> TopGrossing()
        {
            var movies = await _movieService.GetTop30GrossingMovies();
            //return JSON data and always return http status code
            if(movies == null || !movies.Any())
            {
                //404
                return NotFound(new {errorMessage = "No Movies Found"});
            }

            // 200 OK
            // Ok() will convert movies to JSON object
            // ASP.NET Core API will automatically serialize C# objects (movies) to JSON objects
            // in older versions of .NET Framework the JSON serialization was done using a library called Newtonsoft.json
            // Microsoft improved Newtonsoft by creating Microsoft.Text.Json
            return Ok(movies);
        }

        // api/movies/details/id
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return NotFound(new { ErrorMessage = "No Movie FOund" });
            }
            return Ok(movie);
        }
    }
}
