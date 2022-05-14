using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {
        public MovieShopDbContext( DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Trailer> Trailer { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        
        
        // to use Fluent API you need to override "OnModelCreating" method and give it the custom table modeling properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //here we specify the rules for Entity
            modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);

        }

        private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();

        }

        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
        }
    }
}
