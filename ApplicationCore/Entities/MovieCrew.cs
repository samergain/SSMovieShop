using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCrew
    {
        public int MovieId { get; set; }
        public int CrewId { get; set; }
        [MaxLength(2084)]
        public string Department { get; set; }
        [MaxLength(2084)]
        public string Job { get; set; }
        public Movie Movie { get; set; }
        public Crew Crew { get; set; }

    }
}
