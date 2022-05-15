using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Crew
    {
        public int Id { get; set; }
        [MaxLength(256)]
        public string? Name { get; set; }
        [MaxLength(256)]
        public string? Gender { get; set; }
        [MaxLength(2084)]
        public string? TmdbUrl { get; set; }

        [MaxLength(2084)]
        public string? ProfilePath { get; set; }
        ICollection<MovieCrew> CrewMovies { get; set; }
    }
}
