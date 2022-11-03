using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public static class MovieDatabaseExtensions
    {
        // extension method requirments
        // 1. public/internal static class
        // 2. public/internal static method
        // 3. First parameter must be the extended type
        // 4. first parameter must be proceeded by this
        public static void Seed (this IMovieDatabase database)
        {
            var movies = new Movie[] {
                new Movie() {
                    Title = "Jaws",
                    Rating = "PG",
                    RunLength = 210,
                    ReleaseYear = 1977,
                    Description = "Shark eats people",
                    IsClassic = true,
                },
                new Movie() {
                    Title = "Jaws 2",
                    Rating = "PG-13",
                    RunLength = 220,
                    ReleaseYear = 1979,
                    Description = "Shark eats people...again"
                },
                new Movie() {
                    Title = "Dune",
                    Rating = "PG-13",
                    RunLength = 320,
                    ReleaseYear = 1985,
                    Description = "Based on book",
                }
            };
            foreach (var movie in movies)
                database.Add(movie, out var error);
        }
    }
}
