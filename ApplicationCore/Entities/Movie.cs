using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Movie")]
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(256)]
        public string? Title { get; set; }

        [MaxLength(4096)]
        public string? Overview { get; set; }

        [MaxLength(512)]
        public string? Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }

        [MaxLength(2084)]
        public string? ImdbUrl { get; set; }

        [MaxLength(2084)]
        public string? TmdbUrl { get; set; }

        [MaxLength(2084)]
        public string? PosterUrl { get; set; }

        [MaxLength(2084)]
        public string? BackdropUrl { get; set; }

        [MaxLength(128)]
        public string? OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [MaxLength(4096)]
        public string? UpdatedBy { get; set; }

        [MaxLength(4096)]
        public string? CreatedBy { get; set; }

        public ICollection<Trailer> Trailers { get; set; }
        public ICollection<MovieGenre> MoviesOfGenre { get; set; }
        public ICollection<MovieCrew> MovieCrews { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }
        public ICollection<Review> MovieReviews { get; set; }
        public ICollection<Favorite> MovieFavorites { get; set; }
        public ICollection<Purchase> MoviePurchases { get; set; }


    }
}
