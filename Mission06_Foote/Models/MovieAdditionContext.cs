using Microsoft.EntityFrameworkCore;

namespace Mission06_Foote.Models
{
    public class MovieAdditionContext : DbContext
    {
        public MovieAdditionContext(DbContextOptions<MovieAdditionContext> options) : base(options)
        { }

        public DbSet<MovieForm> MovieForms {get; set;}
    }
}
