using System.Reflection;
using EFCoreMovies.Entities;
using ESCoreMoviesDb.Entities.Seeding;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            M3Seeding.Seed(modelBuilder);





            //modelBuilder.Entity<CinemaHall>().Property(p => p.Cost).HasPrecision(9, 2);
            //modelBuilder.Entity<CinemaHall>().Property(p => p.CinemaHallType).HasDefaultValue(CinemaHallType.TwoDimensions);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
    }
}
