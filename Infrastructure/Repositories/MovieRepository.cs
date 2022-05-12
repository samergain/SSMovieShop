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
            return null;
        }
    }
}
