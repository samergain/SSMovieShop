﻿using ApplicationCore.Entities;
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
        public DbSet<Crew> Crew { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }



        // to use Fluent API you need to override "OnModelCreating" method and give it the custom table modeling properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //here we specify the rules for Entity
            modelBuilder.Entity<Genre>(ConfigureGenre);
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
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
        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.HasKey(mc => new { mc.MovieId, mc.CrewId });
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.HasKey(mc => new { mc.MovieId, mc.CastId });
        }
        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ur => new {ur.RoleId, ur.UserId});
        }
    }
}
