using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation property
        ICollection<MovieGenre> GenresOfMovies { get; set; }
    }
}
