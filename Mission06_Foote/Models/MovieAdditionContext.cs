using Microsoft.EntityFrameworkCore;

namespace Mission06_Foote.Models
{
    public class MovieAdditionContext : DbContext
    {
        public MovieAdditionContext(DbContextOptions<MovieAdditionContext> options) : base(options)
        { }

        public DbSet<MovieForm> MovieForms {get; set;}

        public DbSet<Rating> Ratings { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>().HasData(
                new Rating { RatingId = 1, RatingName = "G" },
                new Rating { RatingId = 2, RatingName = "PG" },
                new Rating { RatingId = 3, RatingName = "PG-13" },
                new Rating { RatingId = 4, RatingName = "R" }
                );
        }
    }
}
