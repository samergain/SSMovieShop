using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public List<Movie> GetTop30GrossingMovies()
        {
            //SQL Database
            //data access logic
            //ADO.NET (Microsoft) SQLConnection, SQLCommand
            //Dapper 
            // Entity Framework Core => LINQ
            // select top(30) * from movie order by Revenue
            var movies = new List<Movie>()
            {
                new Movie { Id = 1, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 2, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 3, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 4, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 5, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 6, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 7, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 8, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 9, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 10, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 11, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"},
                new Movie { Id = 12, Title = "Inception", PosterUrl = "https://www.themoviedb.org/t/p/original/edv5CZvWj09upOsy2Y6IwDhK8bt.jpg"}
            };
            return movies;
        }
    }
}
