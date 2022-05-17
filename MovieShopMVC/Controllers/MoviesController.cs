using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieService _movieService;

        public MoviesController(ILogger<MoviesController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public IActionResult Details(int id)
        {
            //go to movies table and get the movie details by ID
            //connect to SQL server and execute the SQL query
            //select * from MOovie where id = 2;
            //get the movies entity (object)
            // create Repositories for Data access Logic
            // Services for Business Logic
            // Controllers action methods => Services methods => Repository methods => SQL db
            // get the model data from the services and send the data to the views (M = Model)
            var movie = _movieService.GetById(id);
            return View(movie);
        }
    }
}
