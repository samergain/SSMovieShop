using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    //[Table("Trailer")]
    public class Trailer
    {
        public int Id { get; set; }
        //to establish the relation the FK should be Movie(parent table name)+Id(PK in parent)
        public int MovieId { get; set; }
        [MaxLength(2048)]
        public string TrailerUrl { get; set; }
        [MaxLength(2048)]
        public string Name { get; set; }
        //Navigation property
        public Movie Movie { get; set; }
    }
}
