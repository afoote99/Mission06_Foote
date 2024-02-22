﻿using Microsoft.EntityFrameworkCore;

namespace Mission06_Foote.Models
{
    //this is our DbContext
    public class MovieAdditionContext : DbContext
    {
        public MovieAdditionContext(DbContextOptions<MovieAdditionContext> options) : base(options)
        { }

        public DbSet<MovieForm> MovieForms {get; set;}

        public DbSet<Categories> Categories { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //instead of changing MovieForm to Movies, just anytimme MovieForm is mentioned associate with Movies
            modelBuilder.Entity<MovieForm>().ToTable("Movies");

            //seeding the data for categories
            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Categories { CategoryId = 2, CategoryName = "Drama" },
                new Categories { CategoryId = 3, CategoryName = "Television" },
                new Categories { CategoryId = 4, CategoryName = "Horror/Suspense" },
                new Categories { CategoryId = 5, CategoryName = "Comedy" },
                new Categories { CategoryId = 6, CategoryName = "Family" },
                new Categories { CategoryId = 7, CategoryName = "Action/Adventure" },
                new Categories { CategoryId = 8, CategoryName = "VHS" }
                );
        }
    }
}
